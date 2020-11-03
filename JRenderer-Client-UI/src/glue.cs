using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JRenderer_Client.src
{
    partial class Backend
    {
        #region Backend_GL_Dll_Import
        public const string BackendDll = "JRenderer-Client-Backend.dll";
        [DllImport(BackendDll)]
        public static extern void InitBackend();
        [DllImport(BackendDll)]
        public static extern IntPtr InitOpenGL(IntPtr hwnd, int width, int height);
        [DllImport(BackendDll)]
        public static extern void OpenGLRender(IntPtr window);
        [DllImport(BackendDll)]
        public static extern void Shutdown(IntPtr window);
        [DllImport(BackendDll)]
        public static extern void ImageRenderTest(int width,int height, [Out] byte[] data);
        #endregion

        #region Backend_Server_GL_Dll_Import
        [DllImport(BackendDll)]
        public static extern IntPtr InitServerOpenGL(IntPtr hwnd,int width,int height);
        [DllImport(BackendDll)]
        public static extern void ServerOpenGLRender(IntPtr window);
        #endregion

        public static void TestImageSending(PpmImage image)
        {
            ImageRenderTest(image.width, image.height, image.rgb);
        }
    }
}
