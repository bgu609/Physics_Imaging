using IdealGas_Simulator.Models;
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
            int Render_Step = 0;

            while (true)
            {
                Thread.Sleep(16);

                if (Render_Step % 6 == 0)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }
                else if (Render_Step % 6 == 1)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, },

                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = 200, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }
                else if (Render_Step % 6 == 2)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, },

                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = 400, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }
                else if (Render_Step % 6 == 3)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, },

                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = 600, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }
                else if (Render_Step % 6 == 4)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, },

                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = 800, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }
                else if (Render_Step % 6 == 5)
                {
                    Task.Run(() => {
                        Initialize_Particles(
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 300, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 500, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 700, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 900, Y = 1000, },
                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00), Radius = 5, X = 1100, Y = 1000, },

                            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = 1000, Y = 1000, }
                        );

                        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
                    });
                }

                Render_Step = (Render_Step + 1) % 6;
            }
        }
    }
}