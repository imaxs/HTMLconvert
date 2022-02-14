using HTMLconvert.Core;
using HTMLconvert.Core.Conventions;
using HTMLconvert.Core.Settings;

namespace HTMLconvert
{
    public class PdfSettings : IPdfSettings
    {
        private MarginSettings m_Margins;

        public PdfSettings()
        {
            m_Margins = new MarginSettings();
        }
        
        /// <summary>
        /// The orientation of the output document, must be either "Landscape" or "Portrait". Default = "portrait"
        /// </summary>
        [WkHtml("orientation")]
        public Orientation? Orientation { get; set; }

        /// <summary>
        /// Should the output be printed in color or gray scale, must be either "Color" or "Grayscale". Default = "color"
        /// </summary>
        [WkHtml("colorMode")]
        public ColorMode? ColorMode { get; set; }

        /// <summary>
        /// Should we use loss less compression when creating the pdf file. Default = true
        /// </summary>
        [WkHtml("useCompression")]
        public bool? UseCompression { get; set; }

        /// <summary>
        /// What dpi should we use when printing. Default = 96
        /// </summary>
        [WkHtml("dpi")]
        public int? DPI { get; set; }

        /// <summary>
        /// A number that is added to all page numbers when printing headers, footers and table of content. Default = 0
        /// </summary>
        [WkHtml("pageOffset")]
        public int? PageOffset { get; set; }

        /// <summary>
        /// How many copies should we print. Default = 1
        /// </summary>
        [WkHtml("copies")]
        public int? Copies { get; set; }

        /// <summary>
        /// Should the copies be collated. Default = true
        /// </summary>
        [WkHtml("collate")]
        public bool? Collate { get; set; }

        /// <summary>
        /// Should a outline (table of content in the sidebar) be generated and put into the PDF. Default = true
        /// </summary>
        [WkHtml("outline")]
        public bool? Outline { get; set; }

        /// <summary>
        /// The maximal depth of the outline. Default = 4
        /// </summary>
        [WkHtml("outlineDepth")]
        public int? OutlineDepth { get; set; }

        /// <summary>
        /// If not set to the empty string a XML representation of the outline is dumped to this file. Default = ""
        /// </summary>
        [WkHtml("dumpOutline")]
        public string DumpOutline { get; set; }

        /// <summary>
        /// The path of the output file, if "-" output is sent to stdout, if empty the output is stored in a buffer. Default = ""
        /// </summary>
        [WkHtml("out")]
        public string Out { get; set; }

        /// <summary>
        /// The title of the PDF document. Default = ""
        /// </summary>
        [WkHtml("documentTitle")]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// The maximal DPI to use for images in the pdf document. Default = 600
        /// </summary>
        [WkHtml("imageDPI")]
        public int? ImageDPI { get; set; }

        /// <summary>
        /// The jpeg compression factor to use when producing the pdf document. Default = 94
        /// </summary>
        [WkHtml("imageQuality")]
        public int? ImageQuality { get; set; }

        /// <summary>
        /// Path of file used to load and store cookies. Default = ""
        /// </summary>
        [WkHtml("load.cookieJar")]
        public string CookieJar { get; set; }

        /// <summary>
        /// Size of output paper
        /// </summary>
        public PaperSize PaperSize { get; set; }

        /// <summary>
        /// The height of the output document
        /// </summary>
        [WkHtml("size.height")]
        public string PaperHeight
        {
            get => PaperSize == null ? null : PaperSize.Height;
        }
        
        /// <summary>
        /// The width of the output document
        /// </summary>
        [WkHtml("size.width")]
        public string PaperWidth
        {
            get => PaperSize == null ? null : PaperSize.Width;
        }

        public MarginSettings Margins
        {
            get => m_Margins;
            set => m_Margins = value;
        }

        /// <summary>
        /// Size of the left margin
        /// </summary>
        [WkHtml("margin.left")]
        public string MarginLeft
        {
            get => m_Margins.GetMarginValue(m_Margins.Left);
        }

        /// <summary>
        /// Size of the right margin
        /// </summary>
        [WkHtml("margin.right")]
        public string MarginRight
        {
            get => m_Margins.GetMarginValue(m_Margins.Right);
        }

        /// <summary>
        /// Size of the top margin
        /// </summary>
        [WkHtml("margin.top")]
        public string MarginTop
        {
            get => m_Margins.GetMarginValue(m_Margins.Top);
        }

        /// <summary>
        /// Size of the bottom margin
        /// </summary>
        [WkHtml("margin.bottom")]
        public string MarginBottom
        {
            get => m_Margins.GetMarginValue(m_Margins.Bottom);
        }
    }
}