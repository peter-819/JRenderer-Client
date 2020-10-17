#pragma once

namespace JRenderer {
	enum class TypeFormat {
		Float,
		Int,
		Byte
	};

	enum class ChannelName {
		Position = 0,
		Color,
		Normal,
		TexCoord0,
		TexCoord1
	};
}