#include "GL/glew.h"
#include <Jpch.h>
#include "RenderSystem/Window.h"
#include "RenderSystem/Device.h"
#include <GL/gl.h>


JRenderer::Window* window;
JRenderer::Device& device = JRenderer::Device::Instance();

float vertices[] = {
    -0.5f, -0.5f, 0.0f,
     0.5f, -0.5f, 0.0f,
     0.0f,  0.5f, 0.0f
};
unsigned int VBO;
unsigned int VAO;
unsigned int vertexShader;
unsigned int fragmentShader;
unsigned int shaderProgram;
void Triangle();

JAPI void InitBackend() {
    Log::Init();
}

JAPI JRenderer::Window* InitOpenGL(HWND hwnd,int width,int height) {
    window = JRenderer::Window::Create(hwnd,width,height);
    device.SetViewport(0, 0, width, height);

    Triangle();
    return window;
}
JAPI void OpenGLRender() {
    window->BeginFrame();
    // render
    // ------
    glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT);
    glUseProgram(shaderProgram);
    glBindVertexArray(VAO);
    glDrawArrays(GL_TRIANGLES, 0, 3);;
    window->EndFrame();
}
JAPI void Shutdown() {
    delete window;
    device.Destroy();
}
const char* vertexShaderSource = R"(
#version 330 core
layout(location = 0) in vec3 aPos;

void main()
{
    gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);
}
)";

const char* fragmentShaderSource = R"(
#version 330 core
out vec4 FragColor;

void main()
{
    FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);
} 
)";

void Triangle(){
    // 着色器
    vertexShader = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertexShader, 1, &vertexShaderSource, NULL);
    glCompileShader(vertexShader);
    // 片段着色器
    fragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragmentShader, 1, &fragmentShaderSource, NULL);
    glCompileShader(fragmentShader);
    // 着色器程序
    shaderProgram = glCreateProgram();
    glAttachShader(shaderProgram, vertexShader);
    glAttachShader(shaderProgram, fragmentShader);
    glLinkProgram(shaderProgram);
    glUseProgram(shaderProgram);
    glDeleteShader(vertexShader);
    glDeleteShader(fragmentShader);
    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(0);

    glGenVertexArrays(1, &VAO);
    glGenBuffers(1, &VBO);
    glBindVertexArray(VAO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindVertexArray(0);

}

JAPI void ImageRenderTest(int width,int height,byte* data) {
    for (int i = 0; i < width * height; i++) {
        std::cout << (int)data[i] << " " << (int)data[i + 1] << " " << (int)data[i + 2] << std::endl;
    }
}