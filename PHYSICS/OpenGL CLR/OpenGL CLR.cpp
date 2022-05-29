#include "pch.h"
#include "OpenGL CLR.h"
#include "include/GL/glew.h"
#include "include/GLFW/glfw3.h"

#pragma comment(lib, "OpenGL32.lib")
#pragma comment(lib, "lib/glew32.lib")
#pragma comment(lib, "lib/glfw3.lib")



namespace OpenGL_CLR
{
	void OpenGL_Lib::Viewport(int x, int y, int width, int height)
	{
		Viewport_Width = width;
		Viewport_Height = height;

		glfwInit();

		glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);
	}

	int OpenGL_Lib::Get_Viewport_Width()
	{
		return Viewport_Width;
	}

	int OpenGL_Lib::Get_Viewport_Height()
	{
		return Viewport_Height;
	}



	Byte* OpenGL_Lib::Get_BitMap()
	{
		Byte* buffer = new Byte[Viewport_Width * Viewport_Height * 4];

		for (int i = 0; i < Viewport_Width * Viewport_Height * 4; i += 4)
		{
			buffer[i] = 0xFF;
			buffer[i + 1] = 0;
			buffer[i + 2] = 0;
			buffer[i + 3] = 0xFF;
		}

		return buffer;
	}
}