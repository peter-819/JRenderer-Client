#include "Jpch.h"
#include "GLProgram.h"

namespace JRenderer {
	Handle GLProgram::GetHandle() {
		Handle handle{ mProgramID };
		return handle;
	}
}