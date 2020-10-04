#include <Windows.h>
#include <iostream>
#include <GL/glew.h>

#define JAPI __declspec(dllexport)

extern "C" {
	JAPI bool InitOpenGL(HWND hwnd,int width,int height) {
		HDC hDC = GetDC(hwnd);

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
        int  iPixelFormat;

        // get the best available match of pixel format for the device context   
        iPixelFormat = ChoosePixelFormat(hDC, &pfd);

        // make that the pixel format of the device context  
        SetPixelFormat(hDC, iPixelFormat, &pfd);

		HGLRC glrc = wglCreateContext(hDC);
		wglMakeCurrent(hDC, glrc);
        auto err = GetLastError();
        glewInit();
        glViewport(0, 0, width, height);
        glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);
        auto glerr = glGetError();
        return true;
	}
}