#pragma once
#include "GLInclude.h"
#include "RenderSystem/Descriptors.h"

namespace JRenderer {
	class GLPSO {
	public:
		GLPSO(PSODesc* desc);
		GLPSO() = delete;
		
		void SetInputLayout();
	private:
		PSODesc mDesc;
	};
}