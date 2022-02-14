# HTMLconvert
### C# .NET Core P/Invoke wrapper for wkhtmltopdf library that uses WebKit to convert HTML to PDF and Image.
**HTMLconvert** is a lightweight and easy to use wrapper for [wkhtmltopdf](https://wkhtmltopdf.org/) library that will help you convert HTML to PDF/Image bytes.

---

#### Installation via NuGet
You can install the library via Nuget ([HTMLconvert.NETCore](https://www.nuget.org/packages/HTMLconvert.NETCore/)). Run below command from package manager console:
```
PM> Install-Package HTMLconvert.NETCore -Version 1.0.0
```

#### Install wkhtmltopdf

##### Ubuntu 20.04:
```console
wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.focal_amd64.deb
sudo apt install ./wkhtmltox_0.12.6-1.focal_amd64.deb
```
##### Ubuntu 18.04:
```console
wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.bionic_amd64.deb
sudo apt install ./wkhtmltox_0.12.6-1.bionic_amd64.deb
```
##### Ubuntu 16.04:
```console
wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.xenial_amd64.deb
sudo apt install ./wkhtmltox_0.12.6-1.xenial_amd64.deb
```
##### Debian 10
```console
wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.buster_amd64.deb
sudo apt install ./wkhtmltox_0.12.6-1.buster_amd64.deb
```
##### Debian 9
```console
wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.stretch_amd64.deb
sudo apt install ./wkhtmltox_0.12.6-1.stretch_amd64.deb
```
##### MacOS
```console
$ brew update && brew cask install wkhtmltopdf
```
---
### Usage

#### Convert a web page to a png bytes
```csharp
var imageConverter = new Converter(new ImageTools(useGraphics: false));

var result = imageConverter.Convert(new ImageSettings()
    {
        Format = "png",
        SmartWidth = true,
        Quality = 100,
        In = "https://google.com/"
    });
                                           
var pathToImage = Path.Combine(Directory.GetCurrentDirectory(), "web.png"); 
File.Delete(pathToImage);

File.WriteAllBytesAsync(pathToImage, result); // Write bytes to .png file
```
---
#### Convert HTML content to a png bytes
```csharp
var htmlContent = @"<!DOCTYPE html><html><head><title>HTML Tables</title></head><body><table><tr><th>First_Name</th><th>Last_Name</th><th>Marks</th></tr><tr><td>Sonoo</td><td>Jaiswal</td><td>60</td></tr><tr><td>James</td><td>William</td><td>80</td></tr><tr><td>Swati</td><td>Sironi</td><td>82</td></tr><tr><td>Chetna</td><td>Singh</td><td>72</td></tr></table></body></html>";

var imageConverter = new Converter(new ImageTools(useGraphics: false));

var result = imageConverter.Convert(new ImageSettings()
    {
        Format = "png",
        SmartWidth = true,
        Quality = 100,
    }, htmlContent);

var pathToImage = Path.Combine(Directory.GetCurrentDirectory(), "HTMLcontent.png"); 
File.Delete(pathToImage);

File.WriteAllBytesAsync(pathToImage, result); // Write bytes to .png file
```
---
#### Convert a web page to a PDF bytes
```csharp
var pdfConverter = new Converter(new PdfTools(useGraphics: false));

var result = pdfConverter.Convert(new PdfSettings()
    {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4,
        Margins = new MarginSettings()
        {
            Top = 10
        }
    },
    new ObjectSettings() {
        Page = "http://google.com/"
    });

var pathToPdf = Path.Combine(Directory.GetCurrentDirectory(), "DocumentWeb.pdf"); 
File.Delete(pathToPdf);

File.WriteAllBytesAsync(pathToPdf, result); // Write bytes to .pdf file
```
---
#### Convert HTML content to a PDF bytes
```csharp
var htmlContent = @"<!DOCTYPE html><html><head><title>HTML Tables</title></head><body><table><tr><th>First_Name</th><th>Last_Name</th><th>Marks</th></tr><tr><td>Sonoo</td><td>Jaiswal</td><td>60</td></tr><tr><td>James</td><td>William</td><td>80</td></tr><tr><td>Swati</td><td>Sironi</td><td>82</td></tr><tr><td>Chetna</td><td>Singh</td><td>72</td></tr></table></body></html>";

var pdfConverter = new Converter(new PdfTools(useGraphics: false));

var result = pdfConverter.Convert(new PdfSettings()
    {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Landscape,
        PaperSize = PaperKind.A4Plus,
    },
    htmlContent,
    new ObjectSettings() {
        PagesCount = true,
        WebSettings =
        {
            DefaultEncoding = "utf-8"
        },
        HeaderSettings = 
        { 
            FontSize = 9, 
            Right = "Page [page] of [toPage]", 
            Line = true, 
            Spacing = 2.812 
        }
    });

var pathToPdf = Path.Combine(Directory.GetCurrentDirectory(), "DocumentHTML.pdf"); 
File.Delete(pathToPdf);

File.WriteAllBytesAsync(pathToPdf, result); // Write bytes to .pdf file
```
