#pragma once

using namespace System;

namespace OpenGL_CLR {
	public ref class OpenGL_Lib
	{
	public:
		int Viewport_Width;
		int Viewport_Height;

		void Viewport(int x, int y, int width, int height);
		int Get_Viewport_Width();
		int Get_Viewport_Height();

		Byte* Get_BitMap();
	};
}
