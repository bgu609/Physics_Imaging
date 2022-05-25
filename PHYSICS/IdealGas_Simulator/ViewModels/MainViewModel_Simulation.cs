using IdealGas_Simulator.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel
    {
        Thread Simulation_Thread;



        private void Simulation_Loop()
        {
            Random Random = new Random();

            int last_x = 1200;
            int last_y = 750;

            Control_One_Particle(last_x, last_y);

            while (true)
            {
                Thread.Sleep(16);

                last_x += Random.Next(-10, 11);
                last_y += Random.Next(-10, 11);

                if (last_x < 0)
                {
                    last_x = 0;
                }
                else if (last_x > 2400)
                {
                    last_x = 2400;
                }

                if (last_y < 0)
                {
                    last_y = 0;
                }
                else if (last_y > 750)
                {
                    last_y = 750;
                }

                Control_One_Particle(last_x, last_y);
            }
        }

        private void Control_One_Particle(int x, int y)
        {
            Task.Run(() => {
                Initialize_Particles(
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 300, Y = 800, },
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 500, Y = 900, },
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 700, Y = 1000, },
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 900, Y = 1100, },
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 1100, Y = 1200, },

                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = x, Y = y, }
                );

                Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
            });
        }
    }
}