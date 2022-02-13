using NUnit.Framework;
using HTMLconvert;
using HTMLconvert.Core.Settings;
using System.IO;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ImageConverterWebTest()
        {
            var pathToImage = Path.Combine(Directory.GetCurrentDirectory(), "web.png"); 
            File.Delete(pathToImage);

            var imageConverter = new Converter(new ImageTools(useGraphics: false));
            
            var result = imageConverter.Convert(new ImageSettings()
                                                        {
                                                            Format = "png",
                                                            SmartWidth = true,
                                                            Quality = 100,
                                                            In = "https://google.com/"
                                                        });
            
            File.WriteAllBytesAsync(pathToImage, result);
            Assert.AreEqual(true, File.Exists(pathToImage));
        }
        
        [Test]
        public void ImageConverterHTMLContentTest()
        {
            var pathToImage = Path.Combine(Directory.GetCurrentDirectory(), "HTMLcontent.png"); 
            File.Delete(pathToImage);
            
            var htmlContent = @"<!DOCTYPE html><html><head><title>HTML Tables</title></head><body><table><tr><th>First_Name</th><th>Last_Name</th><th>Marks</th></tr><tr><td>Sonoo</td><td>Jaiswal</td><td>60</td></tr><tr><td>James</td><td>William</td><td>80</td></tr><tr><td>Swati</td><td>Sironi</td><td>82</td></tr><tr><td>Chetna</td><td>Singh</td><td>72</td></tr></table></body></html>";
            
            var imageConverter = new Converter(new ImageTools(useGraphics: false));
            
            var result = imageConverter.Convert(new ImageSettings()
            {
                Format = "png",
                SmartWidth = true,
                Quality = 100,
            }, htmlContent);
            
            File.WriteAllBytesAsync(pathToImage, result);
            Assert.AreEqual(true, File.Exists(pathToImage));
        }
        
        [Test]
        public void PdfConverterHTMLContentTest()
        {
            var pathToPdf = Path.Combine(Directory.GetCurrentDirectory(), "DocumentHTML.pdf"); 
            File.Delete(pathToPdf);
            
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
            
            File.WriteAllBytesAsync(pathToPdf, result);
            Assert.AreEqual(true, File.Exists(pathToPdf));
        }
        
        [Test]
        public void PdfConverterWebTest()
        {
            var pathToPdf = Path.Combine(Directory.GetCurrentDirectory(), "DocumentWeb.pdf"); 
            File.Delete(pathToPdf);
            
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
            
            File.WriteAllBytesAsync(pathToPdf, result);
            Assert.AreEqual(true, File.Exists(pathToPdf));
        }
    }
}