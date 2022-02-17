using System.Runtime.InteropServices;
using HTMLconvert.Core;
using HTMLconvert.Core.Conventions;
using HTMLconvert.Core.Services;

namespace HTMLconvert
{
    public class ImageTools : Tools, IBasicTools
    {
        protected override void ReleaseManagedResources()
        {
            // Release managed resources
        }
        
        protected override void ReleaseUnmanagedResources()
        {
            // Release unmanaged resources
            WkHtmlTox.wkhtmltoimage_deinit();
        }

        protected bool Initialize(bool useGraphics)
        {
            return WkHtmlTox.wkhtmltoimage_init(useGraphics ? 1 : 0) == 1;
        }
        
        public ImageTools(bool useGraphics = false) : base(useGraphics) { }

        ~ImageTools() => Dispose(false);

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
            return WkHtmlTox.wkhtmltoimage_extended_qt() == 1;
        }

        public string GetVersion()
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltoimage_version());
        }

        public IntPtr CreateGlobalSettings()
        {
            return WkHtmlTox.wkhtmltoimage_create_global_settings();
        }

        public void DestroyGlobalSetting(IntPtr settings)
        {
            WkHtmlTox.wkhtmltoimage_destroy_global_settings(settings);
        }

        public int SetGlobalSetting(IntPtr settings, string name, string value)
        {
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            IntPtr ptrValue = Marshal.StringToHGlobalAnsi(value);

            try
            {
                return WkHtmlTox.wkhtmltoimage_set_global_setting(settings, ptrName, ptrValue);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrName);
                Marshal.FreeHGlobal(ptrValue);
            }
        }

        public string GetGlobalSetting(IntPtr settings, string name)
        {
            byte[] buffer = new byte[1024 * 2];

            IntPtr tempBuffer = Marshal.AllocHGlobal(buffer.Length);
            IntPtr ptrName = Marshal.StringToHGlobalAnsi(name);
            
            try
            {
                WkHtmlTox.wkhtmltoimage_get_global_setting(settings, ptrName, tempBuffer, buffer.Length);
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
            return WkHtmlTox.wkhtmltoimage_create_converter(globalSettings, IntPtr.Zero);
        }

        public IntPtr CreateConverter(IntPtr globalSettings, string htmlContent)
        {
            var data = ToPointer(htmlContent);
            try
            {
                return WkHtmlTox.wkhtmltoimage_create_converter(globalSettings, data);
            }
            finally
            {
                ClearPointer(data);
            }
        }

        public void DestroyConverter(IntPtr converter)
        {
            WkHtmlTox.wkhtmltoimage_destroy_converter(converter);
        }

        public bool Convert(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltoimage_convert(converter);
        }

        public byte[] GetResult(IntPtr converter)
        {
            var length = WkHtmlTox.wkhtmltoimage_get_output(converter, out var resultPointer);
            var result = new byte[length];
            Marshal.Copy(resultPointer, result, 0, length);

            return result;
        }

        public int SetPhaseChangedCallback(IntPtr converter, VoidCallback callback)
        {
            return WkHtmlTox.wkhtmltoimage_set_phase_changed_callback(converter, callback);
        }

        public int SetProgressChangedCallback(IntPtr converter, IntCallback callback)
        {
            return WkHtmlTox.wkhtmltoimage_set_progress_changed_callback(converter, callback);
        }

        public int SetFinishedCallback(IntPtr converter, IntCallback callback)
        {
            return WkHtmlTox.wkhtmltoimage_set_finished_callback(converter, callback);
        }

        public int SetWarningCallback(IntPtr converter, StringCallback callback)
        {
            return WkHtmlTox.wkhtmltoimage_set_warning_callback(converter, callback);
        }

        public int SetErrorCallback(IntPtr converter, StringCallback callback)
        {
            return WkHtmlTox.wkhtmltoimage_set_error_callback(converter, callback);
        }

        public int GetPhaseCount(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltoimage_phase_count(converter);
        }

        public int GetCurrentPhase(IntPtr converter)
        {
            return WkHtmlTox.wkhtmltoimage_current_phase(converter);
        }

        public string GetPhaseDescription(IntPtr converter, int phase)
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltoimage_phase_description(converter, phase));
        }

        public string GetProgressString(IntPtr converter)
        {
            return Marshal.PtrToStringAnsi(WkHtmlTox.wkhtmltoimage_progress_string(converter));
        }
    }
}