using Microsoft.Playwright;

class Program
{
    public static async Task Main(string[] args)
    {
        string url = ReadRequired("Enter URL: ");
        string htmlClass = ReadRequired("Enter HTML class of download button: ");
        string? modalButtonTitle = ReadOptional("Enter Title modal's download button, IF IT EXISTS: ");
        string basePath = ReadRequired("Enter path to the parent folder: ");
        string folderName = ReadRequired("Enter name of the folder: ");

        // Combine into full path
        string downloadPath = Path.Combine(basePath, folderName);

        // Create the folder if it doesn't exist
        Directory.CreateDirectory(downloadPath);

        Console.WriteLine($"Files will be saved to: {downloadPath}");

        using var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            AcceptDownloads = true
        });

        var page = await context.NewPageAsync();

        Console.WriteLine("Opening page...");
        await page.GotoAsync(url);

        var buttons = page.Locator(htmlClass);
        int count = await buttons.CountAsync();

        Console.WriteLine($"Found {count} download buttons");
        for (int i = 0; i < count; i++)
        {
            try
            {
                var btn = buttons.Nth(i);

                await btn.HoverAsync();

                var downloadTask = page.WaitForDownloadAsync();

                await btn.ClickAsync();
                if (!string.IsNullOrWhiteSpace(modalButtonTitle))
                {
                    var modalBtn = page.GetByRole(AriaRole.Button, new() { Name = modalButtonTitle });

                    try
                    {
                        await modalBtn.WaitForAsync(new() { Timeout = 3000 });
                        await modalBtn.ClickAsync();
                    }
                    catch
                    {
                        // Modal exists in config but not on page → ignore
                    }
                }

                var download = await downloadTask;

                string filePath = Path.Combine(downloadPath, download.SuggestedFilename);
                await download.SaveAsAsync(filePath);

                Console.WriteLine($"Downloaded: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on item {i}: {ex.Message}");
            }
        }
        await browser.CloseAsync();
    }
    private static string ReadRequired(string prompt) 
    { 
        string? input;
        
        do 
        { 
            Console.Write(prompt); 
            input = Console.ReadLine();
        } 
        while (string.IsNullOrWhiteSpace(input));
        return input!; 
    }
    private static string? ReadOptional(string prompt)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

        return string.IsNullOrWhiteSpace(input) ? null : input;
    }
}