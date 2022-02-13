using System.Runtime.InteropServices;

namespace HTMLconvert.Core.Conventions
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void VoidCallback(IntPtr converter);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void IntCallback(IntPtr converter, int integer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StringCallback(IntPtr converter, [MarshalAs(UnmanagedType.LPStr)] string str);
    
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WkHtmlAttribute : Attribute
    {
        public string Name { get; private set; }

        public WkHtmlAttribute(string name) => Name = name;
    }
}