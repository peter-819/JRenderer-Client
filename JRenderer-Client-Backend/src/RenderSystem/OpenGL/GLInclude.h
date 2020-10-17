#pragma once

#include "GL/glew.h"

#define GL_GET_ERROR \
	auto glerror = glGetError();\
	JR_ERROR("GLError {} in {}, {}, {}",glerror,__FILE__, __func__, __LINE__);