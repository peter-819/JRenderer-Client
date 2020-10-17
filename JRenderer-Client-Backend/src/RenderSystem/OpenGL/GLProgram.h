#pragma once
#include "GLInclude.h"
#include "RenderSystem/Program.h"

namespace JRenderer {
	class GLProgram : public Program {
	public:
		virtual Handle GetHandle() override;
	private:
		GLuint mProgramID;
	};
}