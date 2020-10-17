#include "Jpch.h"
#include "GLPSO.h"

namespace JRenderer {
	const char* ChannelNameString[MaxChannelNum] = {
		"Position",
		"Color",
		"Normal",
		"TexCoord0",
		"TexCoord1"
	};

	GLPSO::GLPSO(PSODesc* desc) {
		mDesc = *desc;
	}

	GLuint GetSize(TypeFormat format) {
		switch (format) {
		case TypeFormat::Byte:
			return 1;
		case TypeFormat::Float:
			return 4;
		case TypeFormat::Int:
			return 4;
		default:
			assert(false);
			return 0;
		}
	}

	GLenum GetType(TypeFormat format) {
		switch (format) {
		case TypeFormat::Byte:
			return GL_BYTE;
		case TypeFormat::Float:
			return GL_FLOAT;
		case TypeFormat::Int:
			return GL_INT;
		default:
			assert(false);
			return GL_NONE;
		}
	}

	void GLPSO::SetInputLayout()
	{
		for (uint32_t i = 0; i < mDesc.channels; i++) {
			auto programID = mDesc.program->GetHandle().id;
			auto& channel = mDesc.inputLayout.channelInfos[i];
			GLint location = glGetAttribLocation(programID, 
				ChannelNameString[(int)channel.name]);
			if (location == -1) {
				continue;
			}
			glVertexAttribPointer(location, channel.dimension * GetSize(channel.format),
				GetType(channel.format), GL_FALSE, mDesc.inputLayout.stride, (GLvoid*)channel.offset);
			glEnableVertexAttribArray(location);
		}
	}

}