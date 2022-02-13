using System.Runtime.InteropServices;
using HTMLconvert.Core;
using HTMLconvert.Core.Conventions;
using HTMLconvert.Core.Services;

namespace HTMLconvert
{
    public class PdfTools : Tools, IBasicTools, IObjectTools
    {
        protected override void ReleaseManagedResources()
        {
            // Release managed resources
        }
        
        protected override void ReleaseUnmanagedResources()
        {
            // Release unmanaged resources
            WkHtmlTox.wkhtmltopdf_deinit();
        }

        protected bool Initialize(bool useGraphics)
        {
            return WkHtmlTox.wkhtmltopdf_init(useGraphics ? 1 : 0) == 1;
        }

        public PdfTools(bool useGraphics = false) : base(useGraphics) { }

        ~PdfTools() => Dispose(false);

        public void Init()
        {
            if (!m_IsInitialized)
            {
                if (Initialize(m_UseGraphics))
                    m_IsInitialized = true;
            }
        }

        public bool ExtendedQt()
        {
            return WkHtmlTox.wkhtmltopdf_extended_qt() == 1;
        }

        public string GetVersion()
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltopdf_version());
        }
        
        public IntPtr CreateObjectSettings()
        {
            return WkHtmlTox.wkhtmltopdf_create_object_settings();
        }

        public int SetObjectSetting(IntPtr settings, string name, string value)
        {
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            IntPtr ptrValue = Marshal.StringToHGlobalAnsi(value);
            
            try
            {
                return WkHtmlTox.wkhtmltopdf_set_object_setting(settings, ptrName, ptrValue);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrName);
                Marshal.FreeHGlobal(ptrValue);
            }
        }

        public unsafe string GetObjectSetting(IntPtr settings, string name)
        {
            byte[] buffer = new byte[1024 * 2];

            IntPtr tempBuffer = Marshal.AllocHGlobal(buffer.Length);
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            
            try
            {
                WkHtmlTox.wkhtmltopdf_get_object_setting(settings, ptrName, tempBuffer, buffer.Length);
                return GetString(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(tempBuffer);
                Marshal.FreeHGlobal(ptrName);
            }
        }
        
        public void AddObject(IntPtr converter, IntPtr objectSettings, byte[] data)
        {
            WkHtmlTox.wkhtmltopdf_add_object(converter, objectSettings, data);
        }

        public void AddObject(IntPtr converter, IntPtr objectSettings, string data)
        {
            IntPtr ptrData = Marshal.StringToHGlobalAnsi(data);
            
            try
            {
                WkHtmlTox.wkhtmltopdf_add_object(converter, objectSettings, ptrData);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrData);
            }
        }

        public void DestroyObjectSetting(IntPtr settings)
        {
            WkHtmlTox.wkhtmltopdf_destroy_object_settings(settings);
        }

        public IntPtr CreateGlobalSettings()
        {
            return WkHtmlTox.wkhtmltopdf_create_global_settings();
        }

        public void DestroyGlobalSetting(IntPtr settings)
        {
            WkHtmlTox.wkhtmltopdf_destroy_global_settings(settings);
        }

        public int SetGlobalSetting(IntPtr settings, string name, string value)
        {
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            IntPtr ptrValue = Marshal.StringToHGlobalAnsi(value);
            
            try
            {
                return WkHtmlTox.wkhtmltopdf_set_global_setting(settings, ptrName, ptrValue);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrName);
                Marshal.FreeHGlobal(ptrValue);
            }
        }

        public string GetGlobalSetting(IntPtr settings, string name)
        {
            byte[] buffer = new byte[1024 * 4];

            IntPtr tempBuffer = Marshal.AllocHGlobal(buffer.Length);
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            
            try
            {
                WkHtmlTox.wkhtmltopdf_get_global_setting(settings, ptrName, tempBuffer, buffer.Length);
                return GetString(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(tempBuffer);
                Marshal.FreeHGlobal(ptrName);
            }
        }

        public IntPtr CreateConverter(IntPtr globalSettings)
        {
            return WkHtmlTox.wkhtmltopdf_create_converter(globalSettings);
        }

        public IntPtr CreateConverter(IntPtr globalSettings, string htmlContent)
        {
            return WkHtmlTox.wkhtmltopdf_create_converter(globalSettings);
        }

        public void DestroyConverter(IntPtr converter)
        {
            WkHtmlTox.wkhtmltopdf_destroy_converter(converter);
        }

        public bool Convert(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltopdf_convert(converter);
        }

        public byte[] GetResult(IntPtr converter)
        {
            var length = WkHtmlTox.wkhtmltopdf_get_output(converter, out var resultPointer);
            var result = new byte[length];
            Marshal.Copy(resultPointer, result, 0, length);

            return result;
        }

        public int SetPhaseChangedCallback(IntPtr converter, VoidCallback callback)
        {
            return WkHtmlTox.wkhtmltopdf_set_phase_changed_callback(converter, callback);
        }

        public int SetProgressChangedCallback(IntPtr converter, IntCallback callback)
        {
            return WkHtmlTox.wkhtmltopdf_set_progress_changed_callback(converter, callback);
        }

        public int SetFinishedCallback(IntPtr converter, IntCallback callback)
        {
            return WkHtmlTox.wkhtmltopdf_set_finished_callback(converter, callback);
        }

        public int SetWarningCallback(IntPtr converter, StringCallback callback)
        {
            return WkHtmlTox.wkhtmltopdf_set_warning_callback(converter, callback);
        }

        public int SetErrorCallback(IntPtr converter, StringCallback callback)
        {
            return WkHtmlTox.wkhtmltopdf_set_error_callback(converter, callback);
        }

        public int GetPhaseCount(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltopdf_phase_count(converter);
        }

        public int GetCurrentPhase(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltopdf_current_phase(converter);
        }

        public string GetPhaseDescription(IntPtr converter, int phase)
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltopdf_phase_description(converter, phase));
        }

        public string GetProgressString(IntPtr converter)
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltopdf_progress_string(converter));
        }
    }
}