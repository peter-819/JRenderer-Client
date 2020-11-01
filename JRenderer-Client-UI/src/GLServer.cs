using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;

namespace JRenderer_Client.src
{
    class GLServer : HwndHost
    {
        #region Win32_Dll_Import

        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpszClassName,
            string lpszWindowName,
            int style,
            int x, int y,
            int width, int height,
            IntPtr hwndParent,
            IntPtr hMenu,
            IntPtr hInst,
            [MarshalAs(UnmanagedType.AsAny)] object pvParam
        );
        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);
        internal const int WS_CHILD = 0x40000000, WS_VISIBLE = 0x10000000;

        #endregion

        private Border parent;
        private IntPtr hwnd;
        private IntPtr glWindowHandle;
        private Thread renderThread;
        private bool isRunning = true;
        public GLServer(Border border)
        {
            parent = border;
        }
        private void Render(object data)
        {
            glWindowHandle = Backend.InitOpenGL(hwnd, (int)parent.ActualWidth, (int)parent.ActualHeight);
            while (isRunning)
            {
                Backend.OpenGLRender();
            }
            Backend.Shutdown();
        }
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            hwnd = CreateWindowEx(
                0, // dwstyle
                "static", // class name
                "", // window name
                WS_CHILD | WS_VISIBLE, // style
                0, // x
                0, // y
                (int)parent.ActualWidth, // renderWidth
                (int)parent.ActualHeight, // renderHeight
                hwndParent.Handle, // parent handle
                IntPtr.Zero, // menu
                IntPtr.Zero, // hInstance
                0 // param
            );
            renderThread = new Thread(new ParameterizedThreadStart(Render));
            renderThread.Start();
            return new HandleRef(this, hwnd);
        }
        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            isRunning = false;
            renderThread.Join();
            DestroyWindow(hwnd.Handle);
        }
    }
}
