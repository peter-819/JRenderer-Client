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
    class GLHost : HwndHost
    {
        #region DLL_Import
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

        [DllImport("JRenderer-Client-Backend.dll")]
        private static extern bool InitOpenGL(IntPtr hwnd, int width, int height);

        [DllImport("JRenderer-Client-Backend.dll")]
        private static extern void OpenGLRender();
        [DllImport("JRenderer-Client-Backend.dll")]
        private static extern void OpenGLSwapBuffers();
        #endregion

        private Border parent;
        private IntPtr hwnd;
        private Thread renderThread;
        private bool isRunning = true;
        public GLHost(Border border)
        {
            parent = border;
        }
        private void Render(object data)
        {
            InitOpenGL(hwnd, (int)parent.ActualWidth, (int)parent.ActualHeight);
            while (isRunning)
            {
                OpenGLRender();
                OpenGLSwapBuffers();
            }
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
