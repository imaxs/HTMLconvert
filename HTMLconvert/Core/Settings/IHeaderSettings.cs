namespace HTMLconvert.Core.Settings
{
    public interface IHeaderSettings : ISettings
    {
        /// <summary>
        /// The font size to use for the header. Default = 12
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// The name of the font to use for the header. Default = "Ariel"
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// The string to print in the left part of the header, note that some sequences are replaced in this string, see the wkhtmltopdf manual. Default = ""
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// The text to print in the right part of the header, note that some sequences are replaced in this string, see the wkhtmltopdf manual. Default = ""
        /// </summary>
        public string Center { get; set; }

        /// <summary>
        /// The text to print in the right part of the header, note that some sequences are replaced in this string, see the wkhtmltopdf manual. Default = ""
        /// </summary>
        public string Right { get; set; }

        /// <summary>
        /// Whether a line should be printed under the header. Default = false
        /// </summary>
        public bool? Line { get; set; }

        /// <summary>
        /// The amount of space to put between the header and the content, e.g. "1.8". Be aware that if this is too large the header will be printed outside the pdf document. This can be corrected with the margin.top setting. Default = 0.00
        /// </summary>
        public double? Spacing { get; set; }

        /// <summary>
        /// Url for a HTML document to use for the header. Default = ""
        /// </summary>
        public string HtmUrl { get; set; }
    }
}