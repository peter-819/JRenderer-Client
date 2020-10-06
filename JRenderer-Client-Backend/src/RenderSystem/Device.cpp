#include <Jpch.h>
#include "Device.h"
#include "RenderSystem/OpenGL/GLDevice.h"

namespace JRenderer {
	Device& Device::Instance()
	{
		if (!mInstance) {
			mInstance = CreateDevice();
		}
		return (*mInstance);
	}
	Device* Device::CreateDevice()
	{
		switch (RenderAPI) {
		case OpenGL:
			return new GLDevice();
		case DirectX:
		case DXR:
		default:
			assert(false);
			return nullptr;
		}
	}
}