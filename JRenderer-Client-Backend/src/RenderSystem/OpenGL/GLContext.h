#pragma once

#include "GLInclude.h"

namespace JRenderer {
	class GLContext {
	public:
		GLContext(PlatformWindowHandle handle);
		GLContext() = default;
		void MakeCurrent();
		void SwapBuffers();
	private:
		HDC mHDC;
		HGLRC mHGLRC;
		int mPixelFormat;
		PIXELFORMATDESCRIPTOR mPFD;
	};
}