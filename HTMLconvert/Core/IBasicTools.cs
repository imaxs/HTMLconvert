namespace HTMLconvert.Core
{
    using Conventions;
    
    public interface IBasicTools : IDisposable
    {
        void Init();
        
        bool ExtendedQt();
        
        string GetVersion();

        #region Global Settings

        IntPtr CreateGlobalSettings();
        
        void DestroyGlobalSetting(IntPtr settings);
        
        int SetGlobalSetting(IntPtr settings, string name, string val);
        
        string GetGlobalSetting(IntPtr settings, string name);

        #endregion

        void ClearPointer(IntPtr pointer);
        
        IntPtr ToPointer(string htmlContent);
        
        IntPtr CreateConverter(IntPtr globalSettings);
        
        IntPtr CreateConverter(IntPtr globalSettings, string htmlContent);

        void DestroyConverter(IntPtr converter);
        
        bool Convert(IntPtr converter);

        byte[] GetResult(IntPtr converter);

        #region Callbacks

        int SetPhaseChangedCallback(IntPtr converter, VoidCallback callback);

        int SetProgressChangedCallback(IntPtr converter, IntCallback callback);

        int SetFinishedCallback(IntPtr converter, IntCallback callback);

        int SetWarningCallback(IntPtr converter, StringCallback callback);

        int SetErrorCallback(IntPtr converter, StringCallback callback);

        #endregion

        int GetPhaseCount(IntPtr converter);

        int GetCurrentPhase(IntPtr converter);

        string GetPhaseDescription(IntPtr converter, int phase);

        string GetProgressString(IntPtr converter);
    }
}