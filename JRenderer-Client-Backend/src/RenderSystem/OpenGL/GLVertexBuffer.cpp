#include "Jpch.h"
#include "GLVertexBuffer.h"

namespace JRenderer {
	GLVertexBuffer::GLVertexBuffer(VertexBufferDesc* desc)
		:VertexBuffer(desc), mVboID(0) {
		mDesc = *desc;
	}

	void GLVertexBuffer::Init() {
		glGenBuffers(1, &mVboID);
		glBindBuffer(GL_ARRAY_BUFFER, mVboID);
		glBufferData(GL_ARRAY_BUFFER, mDesc.size, mDesc.data, GL_STATIC_DRAW);

		GL_GET_ERROR;
	}
}