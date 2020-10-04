#include <Windows.h>
#include <iostream>
#include <GLFW/glfw3.h>

#define JAPI __declspec(dllexport)

extern "C" {
	JAPI void* InitOpenGL(void* hwnd) {
		return hwnd;
	}
}