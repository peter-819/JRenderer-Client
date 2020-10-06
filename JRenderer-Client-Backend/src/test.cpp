#include <Jpch.h>
#include "RenderSystem/OpenGL/GLWindow.h"

std::shared_ptr<JRenderer::GLWindow> window;
HDC hDC;
JAPI bool InitOpenGL(HWND hwnd,int width,int height) {
    Log::Init();

    window.reset(new JRenderer::GLWindow(hwnd, width, height));
    return true;
}
JAPI void OpenGLRender() {
    window->BeginFrame();
    glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT);
    auto glerr = glGetError();
    window->EndFrame();
}
JAPI void OpenGLSwapBuffers() {
}