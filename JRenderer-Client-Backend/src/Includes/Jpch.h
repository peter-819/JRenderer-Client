#pragma once
#include <iostream>
#include <fstream>
#include <cstdio>

#include <cstdlib>
#include <cstring>
#include <utility>

#include <vector>
#include <list>
#include <map>
#include <string>
#include <set>
#include <algorithm>

#include <type_traits>
#include <chrono>
#include <cassert>
#include <exception>
#include <cstdint>

#ifdef _WINDOWS
#include <Windows.h>
#endif

#include "Utility/Jlog.h"

#define JAPI extern "C" __declspec(dllexport) 


#ifdef _WINDOWS
typedef HWND PlatformWindowHandle;
#else
typedef void* PlatformWindowHandle;
#endif

enum {
	OpenGL,
	DirectX,
	DXR
};
constexpr int RenderAPI = OpenGL;

#include "RenderSystem/RenderEnums.h"


union Handle {
	uint32_t id;
};