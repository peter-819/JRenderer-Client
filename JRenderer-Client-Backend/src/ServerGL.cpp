#include "GL/glew.h"
#include <Jpch.h>
#include "RenderSystem/Window.h"
#include "RenderSystem/Device.h"
#include <GL/gl.h>

float mvertices[] = {
        -1.0f, -1.0f,
        1.0f, -1.0f,
        -1.0f, 1.0f,
        1.0f, 1.0f,
        
        0.0f, 0.0f,
        1.0f, 0.0f,
        0.0f, 1.0f,
        1.0f, 1.0f,
};
unsigned int mVBO;
unsigned int mVAO;
unsigned int mvertexShader;
unsigned int mfragmentShader;
unsigned int mshaderProgram;
unsigned int tex;
void TextureRECT();
const char* mvertexShaderSource = R"(
#version 330 core
layout(location = 0) in vec2 aPos;
layout(location = 1) in vec2 in_tex_coord;
out vec2 tex_coord;

void main()
{
    gl_Position = vec4(aPos.x, aPos.y, 0.0, 1.0);
    tex_coord = in_tex_coord;
}
)";

const char* mfragmentShaderSource = R"(
#version 330 core
in vec2 tex_coord;
out vec4 FragColor;
uniform sampler2D tex;

void main()
{
    //float y = 1.0 - tex_coord.y;
    FragColor = texture(tex,tex_coord);
    //FragColor = vec4(tex_coord.x,tex_coord.y,0,1.0);
} 
)";

JAPI JRenderer::Window* InitServerOpenGL(HWND hwnd, int width, int height) {
    JRenderer::Window* window = JRenderer::Window::Create(hwnd, width, height);
    //glViewport(0, 0, width, height);
    TextureRECT();
    return window;
}

JAPI void ServerOpenGLRender(JRenderer::Window* window,int width, int height, byte* data) {
    window->BeginFrame();
    glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
    glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT);
    glUseProgram(mshaderProgram);
    glBindVertexArray(mVAO); 

    glBindTexture(GL_TEXTURE_2D, tex);
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, width,
        height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);

    glActiveTexture(GL_TEXTURE0);
    glBindTexture(GL_TEXTURE_2D, tex);
    glUniform1i(glGetUniformLocation(mshaderProgram,"tex"), 0);

    glDrawArrays(GL_TRIANGLE_STRIP, 0, 4);
    window->EndFrame();
}
void TextureRECT() {
    // 着色器
    mvertexShader = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(mvertexShader, 1, &mvertexShaderSource, NULL);
    glCompileShader(mvertexShader);
    // 片段着色器
    mfragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(mfragmentShader, 1, &mfragmentShaderSource, NULL);
    glCompileShader(mfragmentShader);
    // 着色器程序
    mshaderProgram = glCreateProgram();
    glAttachShader(mshaderProgram, mvertexShader);
    glAttachShader(mshaderProgram, mfragmentShader);
    glLinkProgram(mshaderProgram);
    glUseProgram(mshaderProgram);
    glDeleteShader(mvertexShader);
    glDeleteShader(mfragmentShader);

    glGenVertexArrays(1, &mVAO);
    glGenBuffers(1, &mVBO);
    glBindVertexArray(mVAO);
    glBindBuffer(GL_ARRAY_BUFFER, mVBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(mvertices), mvertices, GL_STATIC_DRAW);
    glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 0, (void*)0);
    glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 0, (const GLvoid*)(8 * sizeof(float)));
    glEnableVertexAttribArray(0);
    glEnableVertexAttribArray(1);

    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindVertexArray(0);

    glGenTextures(1, &tex);
    glBindTexture(GL_TEXTURE_2D, tex);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
    glBindTexture(GL_TEXTURE_2D, 0);
}