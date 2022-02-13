namespace HTMLconvert.Core.Settings
{
    interface IPdfSettings
    {
        /// <summary>
        /// The orientation of the output document, must be either "Landscape" or "Portrait". Default = "portrait"
        /// </summary>
        Orientation? Orientation { get; set; }

        /// <summary>
        /// Should the output be printed in color or gray scale, must be either "Color" or "Grayscale". Default = "color"
        /// </summary>
        ColorMode? ColorMode { get; set; }

        /// <summary>
        /// Should we use loss less compression when creating the pdf file. Default = true
        /// </summary>
        bool? UseCompression { get; set; }

        /// <summary>
        /// What dpi should we use when printing. Default = 96
        /// </summary>
        int? DPI { get; set; }

        /// <summary>
        /// A number that is added to all page numbers when printing headers, footers and table of content. Default = 0
        /// </summary>
        int? PageOffset { get; set; }

        /// <summary>
        /// How many copies should we print. Default = 1
        /// </summary>
        int? Copies { get; set; }

        /// <summary>
        /// Should the copies be collated. Default = true
        /// </summary>
        bool? Collate { get; set; }

        /// <summary>
        /// Should a outline (table of content in the sidebar) be generated and put into the PDF. Default = true
        /// </summary>
        bool? Outline { get; set; }

        /// <summary>
        /// The maximal depth of the outline. Default = 4
        /// </summary>
        int? OutlineDepth { get; set; }

        /// <summary>
        /// If not set to the empty string a XML representation of the outline is dumped to this file. Default = ""
        /// </summary>
        string DumpOutline { get; set; }

        /// <summary>
        /// The path of the output file, if "-" output is sent to stdout, if empty the output is stored in a buffer. Default = ""
        /// </summary>
        string Out { get; set; }

        /// <summary>
        /// The title of the PDF document. Default = ""
        /// </summary>
        string DocumentTitle { get; set; }

        /// <summary>
        /// The maximal DPI to use for images in the pdf document. Default = 600
        /// </summary>
        int? ImageDPI { get; set; }

        /// <summary>
        /// The jpeg compression factor to use when producing the pdf document. Default = 94
        /// </summary>
        int? ImageQuality { get; set; }

        /// <summary>
        /// Path of file used to load and store cookies. Default = ""
        /// </summary>
        string CookieJar { get; set; }

        /// <summary>
        /// Size of output paper
        /// </summary>
        PaperSize PaperSize { get; set; }

        /// <summary>
        /// The height of the output document
        /// </summary>
        string PaperHeight { get; }

        /// <summary>
        /// The width of the output document
        /// </summary>
        string PaperWidth { get; }

        MarginSettings Margins { get; set; }

        /// <summary>
        /// Size of the left margin
        /// </summary>
        string MarginLeft { get; }

        /// <summary>
        /// Size of the right margin
        /// </summary>
        string MarginRight { get; }

        /// <summary>
        /// Size of the top margin
        /// </summary>
        string MarginTop { get; }

        /// <summary>
        /// Size of the bottom margin
        /// </summary>
        string MarginBottom { get; }
    }
}