using System.Runtime.InteropServices;
using System.Text;

namespace HTMLconvert.Core
{
    public abstract class Tools : IDisposable
    {
        protected bool m_IsInitialized;
        protected bool m_DisposedValue;
        protected bool m_UseGraphics;

        protected abstract void ReleaseManagedResources();
        protected abstract void ReleaseUnmanagedResources();
        
        public Tools(bool useGraphics)
        {
            m_UseGraphics = useGraphics;
        }
        
        public void ClearPointer(IntPtr pointer)
        {
            Marshal.FreeHGlobal(pointer);
        }
        
        public IntPtr ToPointer(string htmlContent)
        {
            if (string.IsNullOrWhiteSpace(htmlContent))
                return IntPtr.Zero;

            byte[] strbuffer = Encoding.UTF8.GetBytes(htmlContent);
            int len = strbuffer.Length;
            IntPtr buffer = Marshal.AllocHGlobal( len + 1);
            Marshal.Copy(strbuffer, 0, buffer, len);

            //Allocated pointer
            IntPtr pointer = new IntPtr(buffer.ToInt64() + len);
            Marshal.WriteByte(pointer, 0);

            return buffer;
        }
        
        protected void Dispose(bool disposing)
        {
            if (!m_DisposedValue)
            {
                if (disposing)
                    ReleaseManagedResources();

                ReleaseUnmanagedResources();
                m_DisposedValue = true;
            }
        }
        
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected string GetString(byte[] buffer)
        {
            int indices = 0;
            
            while (indices < buffer.Length && buffer[indices] != 0) 
                indices++;

            return Encoding.UTF8.GetString(buffer, 0, indices);
        }
    }
}