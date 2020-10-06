#pragma once
#include "Window.h"

namespace JRenderer {
	class Device {
	protected:
		Device(){}
		virtual ~Device(){}
		
	public:
		static Device& Instance();
		virtual void Clear(float r, float g, float b, float a) = 0;
		virtual void SetViewport(int x, int y, int width, int height) = 0;
	public:
		static Device* CreateDevice();
		static void Destroy();
	private:
		static Device* mInstance;
		Window* mBindingWindow;
	};
}