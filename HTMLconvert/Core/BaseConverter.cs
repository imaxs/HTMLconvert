using System.Globalization;
using System.Reflection;
using System.Text;

namespace HTMLconvert.Core
{
    using Settings;
    using Conventions;
    
    public class BaseConverter : IBaseConverter
    {
        public event EventHandler<PhaseChangedArgs> PhaseChanged;
        public event EventHandler<ProgressChangedArgs> ProgressChanged;
        public event EventHandler<FinishedArgs> Finished;
        public event EventHandler<ErrorArgs> Error;
        public event EventHandler<WarningArgs> Warning;

        private IObjectTools m_ObjectTools;
        private IBasicTools m_Tools;

        public BaseConverter(IBasicTools tools)
        {
            m_Tools = tools;
#pragma warning disable CS8601
            m_ObjectTools = tools as IObjectTools;
#pragma warning restore CS8601
        }

        public byte[] Convert(ISettings global, params ISettings[] objects) =>
            Convert(global, String.Empty, objects);
        
        public byte[] Convert(ISettings global, string htmlContent) =>
            Convert(global, htmlContent, null);

        public byte[] Convert(ISettings global, string htmlContent, params ISettings[] objects)
        {
            m_Tools.Init();
            
            IntPtr globalSettings = m_Tools.CreateGlobalSettings();
            BindSettings(globalSettings, global, m_Tools.SetGlobalSetting);
            
            IntPtr converter = global is IImageSettings && !string.IsNullOrEmpty(htmlContent) ?
                                m_Tools.CreateConverter(globalSettings, htmlContent) :
                                m_Tools.CreateConverter(globalSettings);

            if (objects != null && m_ObjectTools != null)
            {
                foreach (var obj in objects)
                {
                    if (obj != null)
                    {
                        IntPtr objectSettings = m_ObjectTools.CreateObjectSettings();
                        BindSettings(objectSettings, obj, m_ObjectTools.SetObjectSetting);
                        m_ObjectTools.AddObject(
                            converter, objectSettings, 
                            string.IsNullOrEmpty(htmlContent) ? null : Encoding.UTF8.GetBytes(htmlContent));
                    }
                }
            }

            m_Tools.SetPhaseChangedCallback(converter, OnPhaseChanged);
            m_Tools.SetProgressChangedCallback(converter, OnProgressChanged);
            m_Tools.SetFinishedCallback(converter, OnFinished);
            m_Tools.SetWarningCallback(converter, OnWarning);
            m_Tools.SetErrorCallback(converter, OnError);
            
            try
            {
                bool isConverted = m_Tools.Convert(converter);
                if (isConverted)
                    return m_Tools.GetResult(converter);
            }
            finally
            {
                m_Tools.DestroyConverter(converter);
            }
            
            return null;
        }
        
        private void BindSettings(IntPtr globalSetting, object setting, Func<IntPtr, string, string, int> setSettings)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var props = setting.GetType().GetProperties(bindingFlags);
            
            foreach (var prop in props)
            {
                Type propType = prop.GetType();
                var argAttribute = prop.GetCustomAttribute<WkHtmlAttribute>();

#pragma warning disable CS8600
                object value = prop.GetValue(setting);
#pragma warning restore CS8600
                
                if (value == null)
                    continue;

                if (argAttribute != null)
                {
                    if (propType == typeof(bool))
                    {
                        setSettings(globalSetting, argAttribute.Name, ((bool)value) ? "true" : "false");
                    }
                    else if (propType == typeof(double))
                    {
                        setSettings(globalSetting, argAttribute.Name, ((double)value).ToString("0.##", CultureInfo.InvariantCulture));
                    }
                    else if (typeof(Dictionary<string, string>).IsAssignableFrom(propType))
                    {
                        var keyValues = (Dictionary<string, string>)value;
                        int index = 0;

                        foreach (var kv in keyValues)
                        {
                            if (kv.Key == null || kv.Value == null)
                                continue;

                            setSettings(globalSetting, $"{argAttribute.Name}.append", null);
                            setSettings(globalSetting, $"{argAttribute.Name}[{index}]", $"{kv.Key}\n{kv.Value}");
                            index++;
                        }
                    }
                    else
                    {
#pragma warning disable CS8604
                        setSettings(globalSetting, argAttribute.Name, value.ToString());
#pragma warning restore CS8604
                    }
                }
                else if (propType == typeof(LoadSettings) || propType == typeof(WebSettings))
                {
                    BindSettings(globalSetting, value, setSettings);
                }

            }
        }
        
        private void OnPhaseChanged(IntPtr converter)
        {
            int currentPhase = m_Tools.GetCurrentPhase(converter);
            var eventArgs = new PhaseChangedArgs()
            {
                PhaseCount = m_Tools.GetPhaseCount(converter),
                CurrentPhase = currentPhase,
                Description = m_Tools.GetPhaseDescription(converter, currentPhase)
            };

            PhaseChanged?.Invoke(this, eventArgs);
        }

        private void OnProgressChanged(IntPtr converter, int value)
        {
            var eventArgs = new ProgressChangedArgs()
            {
                Description = m_Tools.GetProgressString(converter)
            };

            ProgressChanged?.Invoke(this, eventArgs);
        }

        private void OnFinished(IntPtr converter, int success)
        {
            var eventArgs = new FinishedArgs()
            {
                Success = success == 1 ? true : false
            };

            Finished?.Invoke(this, eventArgs);
        }

        private void OnError(IntPtr converter, string message)
        {
            var eventArgs = new ErrorArgs()
            {
                Message = message
            };

            Error?.Invoke(this, eventArgs);
        }

        private void OnWarning(IntPtr converter, string message)
        {
            var eventArgs = new WarningArgs()
            {
                Message = message
            };

            Warning?.Invoke(this, eventArgs);
        }
    }
}