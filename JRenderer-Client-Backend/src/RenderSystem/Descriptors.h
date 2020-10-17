#pragma once
#include "Program.h"

namespace JRenderer {

	constexpr uint32_t MaxChannelNum = 8;
	typedef struct ChannelInfo {
		ChannelName name;
		uint8_t dimension;
		TypeFormat format;
		uint8_t offset;
	} ChannelInfoArray[MaxChannelNum];
	
	struct InputLayoutDesc {
		ChannelInfoArray channelInfos;
		uint32_t stride;
	};

	struct VertexBufferDesc {
		uint8_t* data;
		size_t size;
	};

	struct PSODesc {
		InputLayoutDesc inputLayout;
		Program* program;
		uint32_t channels;
	};
}