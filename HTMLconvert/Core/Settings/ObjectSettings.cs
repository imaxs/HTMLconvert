namespace HTMLconvert.Core.Settings
{
    using Conventions;
    
    public class ObjectSettings : IObjectSettings
    {
        private HeaderSettings m_HeaderSettings;
        private WebSettings m_WebSettings;
        private FooterSettings m_FooterSettings;
        private LoadSettings m_LoadSettings;
        
        public ObjectSettings()
        { 
            m_HeaderSettings = new HeaderSettings(); 
            m_WebSettings = new WebSettings();
            m_FooterSettings = new FooterSettings();
            m_LoadSettings = new LoadSettings();
        }
        
        /// <summary>
        /// The URL or path of the web page to convert, if "-" input is read from stdin. Default = ""
        /// </summary>
        [WkHtml("page")]
        public string Page { get; set; }

        /// <summary>
        /// Should external links in the HTML document be converted into external pdf links. Default = true
        /// </summary>
        [WkHtml("useExternalLinks")]
        public bool? UseExternalLinks { get; set; }

        /// <summary>
        /// Should internal links in the HTML document be converted into pdf references. Default = true
        /// </summary>
        [WkHtml("useLocalLinks")]
        public bool? UseLocalLinks { get; set; }

        /// <summary>
        /// Should we turn HTML forms into PDF forms. Default = false
        /// </summary>
        [WkHtml("produceForms")]
        public bool? ProduceForms { get; set; }

        /// <summary>
        /// Should the sections from this document be included in the outline and table of content. Default = false
        /// </summary>
        [WkHtml("includeInOutline")]
        public bool? IncludeInOutline { get; set; }

        /// <summary>
        /// Should we count the pages of this document, in the counter used for TOC, headers and footers. Default = false
        /// </summary>
        [WkHtml("pagesCount")]
        public bool? PagesCount { get; set; }

        public WebSettings WebSettings {
            get => m_WebSettings;
            set => m_WebSettings = value;
        }

        public HeaderSettings HeaderSettings {
            get => m_HeaderSettings;
            set => m_HeaderSettings = value;
        }

        public FooterSettings FooterSettings {
            get => m_FooterSettings;
            set => m_FooterSettings = value;
        }

        public LoadSettings LoadSettings {
            get => m_LoadSettings;
            set => m_LoadSettings = value;
        }
    }
}