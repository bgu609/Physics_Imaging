using IdealGas_Simulator___OpenGL_.ViewModels.Basis;
using OpenGL_CLR;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IdealGas_Simulator___OpenGL_.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        OpenGL_Lib GL_Lib;

        private WriteableBitmap drawing_space;
        public WriteableBitmap Drawing_Space
        {
            get => drawing_space;
            set { drawing_space = value; OnChanged(); }
        }



        public MainViewModel()
        {
            Drawing_Space = new WriteableBitmap(2400, 1500, 96, 96, PixelFormats.Bgra32, BitmapPalettes.BlackAndWhiteTransparent);

            GL_Lib = new OpenGL_Lib();

            GL_Lib.Viewport(0, 0, 2400, 1500);

            int width = GL_Lib.Get_Viewport_Width();
            int height = GL_Lib.Get_Viewport_Height();

            byte[] collector = new byte[width * height * 4];

            // 이런 방식으로 c++ lib에서 만든 byte array를 c#으로 끌고오는 게 가능 => c++ lib에서 opengl viewport에 그리고 그 버퍼를 받아서 wpf ui 쪽에 던져준다 (그리는 역할을 opengl한테 넘기기, wpf ui는 결과 표출만)
            // 가져오는 것도 필요할 때 가져오면 되고, 이제 그리는 행위를 viewmodel이 비동기로 던져줄 수가 있을 거 같기도
            unsafe {
                byte* pointer = GL_Lib.Get_BitMap();

                fixed (byte* collector_pointer = &collector[0])
                {
                    Buffer.MemoryCopy(pointer, collector_pointer, width * height * 4, width * height * 4);
                }

                Drawing_Space.Lock();
                Buffer.MemoryCopy(pointer, (void*)Drawing_Space.BackBuffer, width * height * 4, width * height * 4);
                Drawing_Space.AddDirtyRect(new Int32Rect(0, 0, width, height));
                Drawing_Space.Unlock();
            }
        }
    }
}