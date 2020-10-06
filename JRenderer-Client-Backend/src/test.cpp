#include <Jpch.h>
#include "RenderSystem/Window.h"
#include <GL/gl.h>

JRenderer::Window* window;
JAPI bool InitOpenGL(HWND hwnd,int width,int height) {
    Log::Init();

    window = JRenderer::Window::Create(hwnd,width,height);
    return true;
}
JAPI void OpenGLRender() {
    window->BeginFrame();
    glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT);
    auto glerr = glGetError();
    window->EndFrame();
}
JAPI void Shutdown() {
    delete window;
}