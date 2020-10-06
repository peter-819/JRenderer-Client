#pragma once
#include <Jpch.h>
#include "Window.h"
#include "RenderSystem/OpenGL/GLWindow.h"

namespace JRenderer {
	Window* Window::Create(PlatformWindowHandle handle, int width, int height)
	{
		switch (RenderAPI) {
		case OpenGL:
			return new GLWindow(handle, width, height);
		case DirectX:
		case DXR:
		default:
			assert(false);
			return nullptr;
		}
	}
}