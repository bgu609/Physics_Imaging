using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace IdealGas_Simulator.ViewModels
{
    public class DrawingSpace : Image
    {
        WriteableBitmap BitMap;
        Thread Drawing_Thread;

        int Async_Invoke_Period = 16;



        public DrawingSpace(int space_width, int space_height)
        {
            BitMap = BitmapFactory.New(space_width, space_height);
            this.Source = BitMap;

            Drawing_Thread = new Thread(Drawing_Loop);
            Drawing_Thread.IsBackground = true;
            Drawing_Thread.Start();
        }



        private void Drawing_Loop()
        {
            while (true)
            {
                Thread.Sleep(Async_Invoke_Period);

                Sample_Draw();
            }
        }

        private void Sample_Draw()
        {
            Application.Current.Dispatcher.Invoke(() => {
                WriteableBitmapExtensions.DrawLineAa(BitMap, 100, 510, 1500, 510, Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), 2);
                WriteableBitmapExtensions.FillTriangle(BitMap, 100, 1000, 1500, 1000, 800, 1500, Color.FromArgb(0xFF, 0x00, 0x00, 0xFF));
            });

            Thread.Sleep(1000);

            Application.Current.Dispatcher.Invoke(() => {
                WriteableBitmapExtensions.Clear(BitMap, Color.FromArgb(0x00, 0x00, 0x00, 0x00));
            });

            Thread.Sleep(1000);
        }
    }
}