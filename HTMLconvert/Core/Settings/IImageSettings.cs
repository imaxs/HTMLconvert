namespace HTMLconvert.Core.Settings
{
    interface IImageSettings : ISettings
    {
        /// <summary>
        /// Left / x coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        int? Left { get; set; }
        
        /// <summary>
        /// Top / y coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        int? Top { get; set; }
        
        /// <summary>
        /// Width of the window to capture in pixels. E.g. "200"
        /// </summary>
        int? Width { get; set; }

        /// <summary>
        /// Height of the window to capture in pixels. E.g. "200"
        /// </summary>
        int? Height { get; set; }
        
        /// <summary>
        /// Path of file used to load and store cookies.
        /// </summary>
        string CookieJar { get; set; }

        /// <summary>
        /// Page specific settings related to loading content, see Object Specific loading settings.
        /// </summary>
        LoadSettings LoadSettings { get; set; }

        /// <summary>
        /// See Web page specific settings.
        /// </summary>
        WebSettings WebSettings { get; set; }

        /// <summary>
        /// When outputting a PNG or SVG, make the white background transparent. Must be either "true" or "false"
        /// </summary> 
        bool? Transparent { get; set; }
        
        /// <summary>
        /// The URL or path of the input file, if "-" stdin is used. E.g. "http://google.com"
        /// </summary>       
        string In { get; set; }

        /// <summary>
        ///  The path of the output file, if "-" stdout is used, if empty the content is stored to a internalBuffer.
        /// </summary>
        string Out { get; set; }

        /// <summary>
        /// The output format to use, must be either "", "jpg", "png", "bmp" or "svg".
        /// </summary>
        string Format { get; set; }

        /// <summary>
        /// The with of the screen used to render is pixels, e.g "800".
        /// </summary>
        int ScreenWidth { get; set; }

        /// <summary>
        /// The with of the screen used to render is pixels, e.g "800".
        /// </summary>
        int ScreenHeight { get; set; }
        
        /// <summary>
        /// Should we expand the screenWidth if the content does not fit? must be either "true" or "false".
        /// </summary>
        bool? SmartWidth { get; set; }
        
        /// <summary>
        /// The compression factor to use when outputting a JPEG image. E.g. "94".
        /// </summary>
        int? Quality { get; set; }
        
        int LogLevel { get; set; }
    }
}