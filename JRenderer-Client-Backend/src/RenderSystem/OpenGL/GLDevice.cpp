#include "Jpch.h"
#include "GLDevice.h"
#include "GLInclude.h"

namespace JRenderer {
	void JRenderer::GLDevice::Clear(float r, float g, float b, float a){
		glClearColor(r, g, b, a);
		glClear(GL_COLOR_BUFFER_BIT);
	}
	void GLDevice::SetViewport(int x, int y, int width, int height){
		glViewport(x, y, width, height);
	}
}