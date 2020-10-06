#include <Jpch.h>
#include "GLWindow.h"

namespace JRenderer {
	GLWindow::GLWindow(PlatformWindowHandle handle,int width,int height):Window(width,height) {
		mContext.reset(new GLContext(handle));
	}

	void GLWindow::BeginFrame() {

	}

	void GLWindow::EndFrame(){
		mContext->SwapBuffers();
	}
}