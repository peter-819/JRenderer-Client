#pragma once
#include "Jpch.h"

namespace JRenderer {
	class Window {
	public:
		virtual void BeginFrame() = 0;
		virtual void EndFrame() = 0;
	protected:
		Window(int width, int height) :mWidth(width), mHeight(height){}
		Window() = delete;
		virtual ~Window(){}
		int mWidth, mHeight;
	};
}