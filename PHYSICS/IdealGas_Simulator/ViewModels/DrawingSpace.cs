using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



        public DrawingSpace(int space_width, int space_height)
        {
            BitMap = BitmapFactory.New(space_width, space_height);
            this.Source = BitMap;
        }



        public void Clear_Particles()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                WriteableBitmapExtensions.Clear(BitMap);
            }));
        }

        public void Now_Rendering_Particles(List<PixelParticle> Particle_List)
        {
            //Application.Current.Dispatcher.Invoke(() => {
            //    BitMap.Lock();
            //});
            
            //Clear_Particles();
            //await Async_Rendering(Particle_List);
            //Task.Run(() => Sync_Rendering(Particle_List));
            Sync_Rendering(Particle_List);

            //Application.Current.Dispatcher.Invoke(() => {
            //    BitMap.Unlock();
            //});
        }

        private async Task Async_Rendering(List<PixelParticle> Particle_List)
        {
            List<PixelParticle> Collector = Particle_List.ToList();
            List<Task> Task_List = new List<Task>() // Boundary 그리기
            {
                Task.Run(() => {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                        WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 100, 1600, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                    }));
                }),
                Task.Run(() => {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                        WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 100, 1600, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                    }));
                }),
                Task.Run(() => {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                        WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 1400, 800, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                    }));
                }),
                Task.Run(() => {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                        WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 1400, 800, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                    }));
                }),
            };

            foreach (PixelParticle item in Collector) // Particles 그리기
            {
                Task_List.Add(Task.Run(() => {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        WriteableBitmapExtensions.FillEllipse(BitMap, item.X, item.Y, item.X + item.Radius * 2, item.Y + item.Radius * 2, item.Color);
                    }));
                }));
            }

            await Task.WhenAll(Task_List);
        }

        private void Sync_Rendering(List<PixelParticle> Particle_List)
        {
            List<PixelParticle> Collector = Particle_List.ToList();

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => {
                WriteableBitmapExtensions.Clear(BitMap);
                WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 100, 1600, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 100, 1600, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 1400, 800, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
                WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 1400, 800, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);

                foreach (PixelParticle item in Collector)
                {
                    WriteableBitmapExtensions.FillEllipse(BitMap, item.X, item.Y, item.X + item.Radius * 2, item.Y + item.Radius * 2, item.Color);
                }
            }));

            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
            //    WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 100, 1600, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            //}));

            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
            //    WriteableBitmapExtensions.DrawLineAa(BitMap, 1600, 1400, 800, 1400, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            //}));

            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
            //    WriteableBitmapExtensions.DrawLineAa(BitMap, 800, 1400, 800, 100, Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), 20);
            //}));

            //foreach (PixelParticle item in Collector) // Particles 그리기
            //{
            //    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            //    {
            //        WriteableBitmapExtensions.FillEllipse(BitMap, item.X, item.Y, item.X + item.Radius * 2, item.Y + item.Radius * 2, item.Color);
            //    }));
            //}
        }
    }
}