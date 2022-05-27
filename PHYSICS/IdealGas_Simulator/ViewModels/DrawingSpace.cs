using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IdealGas_Simulator.ViewModels
{
    public class DrawingSpace : Image
    {
        WriteableBitmap BitMap;



        public DrawingSpace(int space_width, int space_height)
        {
            BitMap = BitmapFactory.New(space_width, space_height);
            this.Source = BitMap;
        }



        public void Clear_Particles()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                WriteableBitmapExtensions.Clear(BitMap);
            }));
        }

        public void Now_Rendering_Particles(List<PixelParticle> Particle_List)
        {
            Sync_Rendering(Particle_List);
        }

        private void Sync_Rendering(List<PixelParticle> Particle_List)
        {
            List<PixelParticle> Collector = Particle_List.ToList();

            WriteableBitmapExtensions.Clear(BitMap);
            WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 100, 1600, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 100, 1600, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 1400, 800, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 1400, 800, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);

            foreach (PixelParticle item in Collector)
            {
                WriteableBitmapExtensions.FillEllipse(BitMap, item.X, item.Y, item.X + item.Radius * 2, item.Y + item.Radius * 2, item.Color);
            }
        }
    }
}