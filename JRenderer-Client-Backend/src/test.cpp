#include <Jpch.h>
#include "RenderSystem/Window.h"
#include "RenderSystem/Device.h"
#include <GL/gl.h>

JRenderer::Window* window;
JRenderer::Device& device = JRenderer::Device::Instance();
JAPI bool InitOpenGL(HWND hwnd,int width,int height) {
    Log::Init();

    window = JRenderer::Window::Create(hwnd,width,height);
    device.SetViewport(0, 0, width, height);
    return true;
}
JAPI void OpenGLRender() {
    window->BeginFrame();
    device.Clear(0.2f, 0.3f, 0.3f, 1.0f);
    window->EndFrame();
}
JAPI void Shutdown() {
    delete window;
    device.Destroy();
}