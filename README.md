# 🖼️ Web Image Downloader (Playwright C#)

A simple but flexible **C# console application** that automates downloading images from a web page using browser automation.

It uses Microsoft Playwright to interact with dynamic websites, click download buttons, optionally handle modal dialogs, and save files locally.

---

## 🚀 Features

- 🌐 Loads any user-provided URL
- 🖱️ Automatically clicks download buttons on the page
- 🪟 Optionally handles modal dialogs (e.g. "Original" download option)
- 📁 Saves downloads to a user-defined folder
- ⚙️ Fully interactive console input
- 🔄 Works with dynamically loaded JavaScript content

---

## 🧠 How it works

The app uses a headless browser to simulate real user behavior:

1. Opens the provided URL  
2. Finds all download buttons using a CSS selector  
3. Clicks each button one by one  
4. If a modal appears, optionally clicks a second button (e.g. "Original")  
5. Captures the download event  
6. Saves the file to a specified folder  

---

## 📦 Requirements

- .NET 7 or .NET 8 SDK
- Microsoft Playwright for .NET

---

## 🛠️ Installation

Clone the repository:

```bash
git clone https://github.com/your-username/web-image-downloader.git
cd web-image-downloader
```
Install dependencies:

```bash
dotnet restore
```
Install Playwright browsers:
```bash
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
```

## ▶️ Usage
Run the application:

```bash
dotnet run
```
You will be prompted for:

- 🔗 URL of the webpage  
- 🎯 CSS selector for download buttons  
- 🪟 Optional modal button title (press Enter to skip)  
- 📂 Folder path  
- 📁 Folder name
- 
### 💡 Example input
```bash
Enter URL: https://example.com/gallery
Enter HTML class of download button: button.piece__control--download
Enter Title modal's download button (press Enter if none): Original
Enter path to the parent folder: C:\Downloads
Enter name of the folder: MyImages
```
### 📁 Output

Downloaded files are saved to:
```bash
C:\Downloads\MyImages
```
### ⚙️ Configuration Notes
- If a modal button is not present, the app automatically skips it
- Works best with sites that expose visible download buttons
- Designed for dynamic JavaScript-heavy pages
  
##⚠️ Limitations
- Some websites may block automation or require login
- Selectors must be correct for each site
- Highly dynamic layouts may require adjustments
- Not intended for bypassing paywalls or protected content

##🧩 Tech Stack
- C# (.NET)
- Microsoft Playwright Microsoft Playwright
- Chromium automation
  
## 📌 Future Improvements
- Auto-detect download buttons
- Recursive gallery crawling
- Image filtering (size/type)
- Parallel downloads
- UI version (WPF or web dashboard)
  
## 📄 License

This project is open-source and available under the MIT License.

## 🤝 Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you’d like to change.

## ⭐ If you like this project

Give it a star ⭐ and feel free to fork it for your own
