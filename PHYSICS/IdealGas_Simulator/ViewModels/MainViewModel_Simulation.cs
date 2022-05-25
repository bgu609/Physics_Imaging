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

            int Last_X = 1200;
            int Last_Y = 750;

            Control_One_Particle(Last_X, Last_Y);

            while (true)
            {
                Thread.Sleep(16);

                double Move_Radius = Random.Next(-5, 6);
                double Move_Radius_Decimal = Random.NextDouble();
                int Move_Radius_Decimal_Sign = Random.Next(0, 2);

                double Move_Azimuth = Random.Next(0, 361);
                double Move_Azimuth_Decimal = Random.NextDouble();
                int Move_Azimuth_Decimal_Sign = Random.Next(0, 2);

                Move_Radius += (double)(Move_Radius_Decimal * ((Move_Radius_Decimal_Sign == 1) ? 1 : -1));
                Move_Azimuth += (double)(Move_Azimuth_Decimal * ((Move_Azimuth_Decimal_Sign == 1) ? 1 : -1));

                // 일단 귀찮으니 사사오입 반올림 사용
                Last_X += (int)Math.Round(Move_Radius * Math.Sin(Move_Azimuth));
                Last_Y += (int)Math.Round(Move_Radius * Math.Cos(Move_Azimuth));


                // Boundary Condition
                if (Last_X < 810)
                {
                    Last_X = 810;
                }
                else if (Last_X > 1590)
                {
                    Last_X = 1590;
                }

                if (Last_Y < 110)
                {
                    Last_Y = 110;
                }
                else if (Last_Y > 1390)
                {
                    Last_Y = 1390;
                }

                Control_One_Particle(Last_X, Last_Y);
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