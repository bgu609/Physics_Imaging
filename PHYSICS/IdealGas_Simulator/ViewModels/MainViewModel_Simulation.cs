using IdealGas_Simulator.Models;
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
            int Last_X = 1200;
            int Last_Y = 750;

            int Entropy = 10;
            int Particles_Number = 4400;

            PixelParticle[] Initial_Particles = new PixelParticle[Particles_Number];
            for (int i = 0; i < Initial_Particles.Length; i++)
            {
                Initial_Particles[i] = new PixelParticle() {
                    Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF),
                    Seed = i,
                    Entropy = Entropy,
                    Dimension = 2,
                    Radius = 5,
                    X = Last_X,
                    Y = Last_Y,
                };
            }

            X_Boundary_Min = 810;
            X_Boundary_Max = 1590;
            Y_Boundary_Min = 110;
            Y_Boundary_Max = 1390;
            Z_Boundary_Min = 0;
            Z_Boundary_Max = 0;

            Task.Run(() => Initialize_Particles(Initial_Particles));

            while (true)
            {
                Thread.Sleep(16);

                Control_Multi_Particles();
            }
        }

        private void Initialize_Particles(params PixelParticle[] particle)
        {
            Pixel_Particles.Clear();

            List<PixelParticle> Emitter = new List<PixelParticle>();
            foreach (PixelParticle item in particle)
            {
                Emitter.Add(item);
            }

            Pixel_Particles = Emitter;
        }

        private async void Control_Multi_Particles()
        {
            List<Task> Task_List = new List<Task>();

            foreach (PixelParticle item in Pixel_Particles)
            {
                Task_List.Add(Task.Run(() => {
                    Invoke_Probability_Position(item);
                }));
            }

            await Task.WhenAll(Task_List);

            Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
        }
    }
}