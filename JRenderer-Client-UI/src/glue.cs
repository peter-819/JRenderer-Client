using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JRenderer_Client.src
{
    partial class glue 
    {
        private const string BackendDll = "JRenderer-Client-Backend.dll";
        [DllImport(BackendDll)]
        public static extern void ImageRenderTest(int width,int height, [Out] byte[] data);

        public static void TestImageSending(PpmImage image)
        {
            ImageRenderTest(image.width, image.height, image.rgb);
        }
    }
}
