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

#include <type_traits>

#ifdef _WINDOWS
#include <Windows.h>
#endif

#include "../Jlog.h"

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