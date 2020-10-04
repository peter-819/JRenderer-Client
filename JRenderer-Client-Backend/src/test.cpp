#include <Windows.h>
#include <iostream>

#define JAPI __declspec(dllexport)

extern "C" {
	JAPI void* InitOpenGL(void* hwnd) {
		return hwnd;
	}
}