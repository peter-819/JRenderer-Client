#pragma once
#include "RenderSystem/VertexBuffer.h"
#include "GLInclude.h"

namespace JRenderer {
	class GLVertexBuffer : public VertexBuffer {
	public:
		GLVertexBuffer(VertexBufferDesc* desc);
		GLVertexBuffer() = delete;

		void Init();

	private:
		GLuint mVboID;
		VertexBufferDesc mDesc;
	};
}