#pragma once

#include "D3DInclude.h"
#include "RenderSystem/Window.h"

namespace JRenderer {
	class D3DWindow : public Window {
	public:
		D3DWindow(PlatformWindowHandle handle, int width, int height);
		virtual ~D3DWindow();
	};
}