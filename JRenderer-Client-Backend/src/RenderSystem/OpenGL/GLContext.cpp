#include "Jpch.h"
#include "GLContext.h"
#include "GLInclude.h"

namespace JRenderer {
	GLContext::GLContext(PlatformWindowHandle handle)
	{
        mHDC = GetDC(handle);
        PIXELFORMATDESCRIPTOR pfd = {
            sizeof(PIXELFORMATDESCRIPTOR),   // size of this pfd  
            1,                     // version number  
            PFD_DRAW_TO_WINDOW |   // support window  
            PFD_SUPPORT_OPENGL |   // support OpenGL  
            PFD_DOUBLEBUFFER,      // double buffered  
            PFD_TYPE_RGBA,         // RGBA type  
            24,                    // 24-bit color depth  
            0, 0, 0, 0, 0, 0,      // color bits ignored  
            0,                     // no alpha buffer  
            0,                     // shift bit ignored  
            0,                     // no accumulation buffer  
            0, 0, 0, 0,            // accum bits ignored  
            32,                    // 32-bit z-buffer  
            0,                     // no stencil buffer  
            0,                     // no auxiliary buffer  
            PFD_MAIN_PLANE,        // main layer  
            0,                     // reserved  
            0, 0, 0                // layer masks ignored  
        };

        // get the best available match of pixel format for the device context   
        mPixelFormat = ChoosePixelFormat(mHDC, &pfd);

        // make that the pixel format of the device context  
        SetPixelFormat(mHDC, mPixelFormat, &pfd);

        mHGLRC = wglCreateContext(mHDC);
        
        MakeCurrent();

        glewInit();
	}
    
    void GLContext::MakeCurrent() {
        wglMakeCurrent(mHDC, mHGLRC);
    }

    void GLContext::SwapBuffers() {
        ::SwapBuffers(mHDC);
    }
}