#pragma once

#include "RenderSystem/Device.h"

namespace JRenderer {
	class GLDevice : public Device{
	public:
		GLDevice(){}
		virtual ~GLDevice(){}
		virtual void Clear(float r, float g, float b, float a) override;
		virtual void SetViewport(int x, int y, int width, int height) override;
	};
}