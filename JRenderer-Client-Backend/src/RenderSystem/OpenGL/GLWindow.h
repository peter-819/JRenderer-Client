#pragma once
#include "RenderSystem/Window.h"
#include "GLContext.h"

namespace JRenderer {
	class GLWindow : public Window {
	public:
		GLWindow(PlatformWindowHandle handle,int width,int height);
		virtual ~GLWindow() override{}

		virtual void BeginFrame() override;
		virtual void EndFrame() override;
	private:
		std::unique_ptr<GLContext> mContext;
	};
	
}