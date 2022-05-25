using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;
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

                int def_x = Random.Next(-10, 11);
                int def_y = Random.Next(-10, 11);

                // 항상 움직이게
                if (def_x == 0)
                {
                    int sign = Random.Next(0, 2);

                    if (sign == 0)
                    {
                        def_x = 1;
                    }
                    else
                    {
                        def_x = -1;
                    }
                }

                if (def_y == 0)
                {
                    int sign = Random.Next(0, 2);

                    if (sign == 0)
                    {
                        def_y = 1;
                    }
                    else
                    {
                        def_y = -1;
                    }
                }

                last_x += def_x;
                last_y += def_y;

                // Boundary Condition
                if (last_x < 810)
                {
                    last_x = 810;
                }
                else if (last_x > 1590)
                {
                    last_x = 1590;
                }

                if (last_y < 110)
                {
                    last_y = 110;
                }
                else if (last_y > 1390)
                {
                    last_y = 1390;
                }

                Control_One_Particle(last_x, last_y);
            }
        }

        private void Initialize_Particles(params PixelParticle[] particle)
        {
            Pixel_Particles.Clear();

            List<PixelParticle> Emitter = new List<PixelParticle>();
            //Emitter.AddRange(new List<PixelParticle>() {
            //    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 300, Y = 800, },
            //    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 500, Y = 900, },
            //    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 700, Y = 1000, },
            //    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 900, Y = 1100, },
            //    new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 10, X = 1100, Y = 1200, },
            //});

            foreach (PixelParticle item in particle)
            {
                Emitter.Add(item);
            }

            Pixel_Particles = Emitter;
        }

        private void Control_One_Particle(int x, int y)
        {
            Task.Run(() => {
                Initialize_Particles(
                    new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = x, Y = y, }
                );

                Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
            });
        }
    }
}