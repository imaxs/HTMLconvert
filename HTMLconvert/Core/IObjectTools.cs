namespace HTMLconvert.Core
{
    public interface IObjectTools
    {
        IntPtr CreateObjectSettings();
        int SetObjectSetting(IntPtr settings, string name, string value);
        string GetObjectSetting(IntPtr settings, string name);
        void DestroyObjectSetting(IntPtr settings);
        void AddObject(IntPtr converter, IntPtr objectSettings, byte[] data);
        void AddObject(IntPtr converter, IntPtr objectSettings, string data);
    }
}