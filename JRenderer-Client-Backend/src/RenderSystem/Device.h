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

	public:
		static Device* CreateDevice();
	private:
		static Device* mInstance;
		Window* mBindingWindow;
	};
}