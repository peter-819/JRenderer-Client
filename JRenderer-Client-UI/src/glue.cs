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
        #region Backend_Dll_Import
        public const string BackendDll = "JRenderer-Client-Backend.dll";
        [DllImport(BackendDll)]
        public static extern void InitBackend();
        [DllImport(BackendDll)]
        public static extern IntPtr InitOpenGL(IntPtr hwnd, int width, int height);
        [DllImport(BackendDll)]
        public static extern void OpenGLRender();
        [DllImport(BackendDll)]
        public static extern void Shutdown();
        [DllImport(BackendDll)]
        public static extern void ImageRenderTest(int width,int height, [Out] byte[] data);
        #endregion

        public static void TestImageSending(PpmImage image)
        {
            ImageRenderTest(image.width, image.height, image.rgb);
        }
    }
}
