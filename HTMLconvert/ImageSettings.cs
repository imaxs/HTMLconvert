using HTMLconvert.Core.Conventions;
using HTMLconvert.Core.Settings;

namespace HTMLconvert
{
    public class ImageSettings : IImageSettings
    {
        private WebSettings m_WebSettings;
        private LoadSettings m_LoadSettings;

        public ImageSettings()
        {
            m_WebSettings = new WebSettings();
            m_LoadSettings = new LoadSettings();
        }
        
        /// <summary>
        /// Left / x coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        [WkHtml("crop.left")]
        public int? Left { get; set; }
        
        /// <summary>
        /// Top / y coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        [WkHtml("crop.top")]
        public int? Top { get; set; }
        
        /// <summary>
        /// Width of the window to capture in pixels. E.g. "200"
        /// </summary>
        [WkHtml("crop.width")]
        public int? Width { get; set; }

        /// <summary>
        /// Height of the window to capture in pixels. E.g. "200"
        /// </summary>
        [WkHtml("crop.height")]
        public int? Height { get; set; }
        
        /// <summary>
        /// Path of file used to load and store cookies.
        /// </summary>
        [WkHtml("load.cookieJar")]
        public string CookieJar { get; set; }

        /// <summary>
        /// Page specific settings related to loading content, see Object Specific loading settings.
        /// </summary>
        public LoadSettings LoadSettings {
            get => m_LoadSettings;
            set => m_LoadSettings = value;
        }
   
        /// <summary>
        /// See Web page specific settings.
        /// </summary>
        public WebSettings WebSettings {
            get => m_WebSettings;
            set => m_WebSettings = value;
        }
        
        /// <summary>
        /// When outputting a PNG or SVG, make the white background transparent. Must be either "true" or "false"
        /// </summary> 
        [WkHtml("transparent")]
        public bool? Transparent { get; set; }
        
        /// <summary>
        /// The URL or path of the input file, if "-" stdin is used. E.g. "http://google.com"
        /// </summary>       
        [WkHtml("in")]
        public string In { get; set; }

        /// <summary>
        ///  The path of the output file, if "-" stdout is used, if empty the content is stored to a internalBuffer.
        /// </summary>
        [WkHtml("out")]
        public string Out { get; set; }

        /// <summary>
        /// The output format to use, must be either "", "jpg", "png", "bmp" or "svg".
        /// </summary>
        [WkHtml("fmt")]
        public string Format { get; set; }

        /// <summary>
        /// The with of the screen used to render is pixels, e.g "800".
        /// </summary>
        [WkHtml("screenWidth")]
        public int ScreenWidth { get; set; }

        /// <summary>
        /// The with of the screen used to render is pixels, e.g "800".
        /// </summary>
        [WkHtml("screenHeight")]
        public int ScreenHeight { get; set; }
        
        /// <summary>
        /// Should we expand the screenWidth if the content does not fit? must be either "true" or "false".
        /// </summary>
        [WkHtml("smartWidth")]
        public bool? SmartWidth { get; set; }
        
        /// <summary>
        /// The compression factor to use when outputting a JPEG image. E.g. "94".
        /// </summary>
        [WkHtml("quality")]
        public int? Quality { get; set; }
        
        [WkHtml("logLevel")]
        public int LogLevel { get; set; }
    }
}