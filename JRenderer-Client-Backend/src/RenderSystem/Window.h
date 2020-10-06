#pragma once
#include "Jpch.h"

namespace JRenderer {
	class Window {
	public:
		static Window* Create(PlatformWindowHandle handle, int width, int height);
		virtual void BeginFrame() = 0;
		virtual void EndFrame() = 0;
		virtual ~Window() {}
	protected:
		Window(int width, int height) :mWidth(width), mHeight(height){}
		Window() = delete;
		int mWidth, mHeight;
	};
}