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
            X_Boundary_Min = 805;
            X_Boundary_Max = 1585;
            Y_Boundary_Min = 105;
            Y_Boundary_Max = 1385;
            Z_Boundary_Min = -5;
            Z_Boundary_Max = -5;

            Task.Run(() => Initialize_Particles(Number_of_Particles, Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Pixel_Particles_Energy, 2, 5, 1200, 750));

            while (true)
            {
                Thread.Sleep(10);

                Control_Multi_Particles();
            }
        }

        private void Initialize_Particles(int number, Color color, int energy, int dimension, int radius, int init_x, int init_y)
        {
            if (Pixel_Particles == null) Pixel_Particles = new List<PixelParticle>();

            Pixel_Particles.Clear();

            PixelParticle[] Initial_Particles = new PixelParticle[number];
            for (int i = 0; i < Initial_Particles.Length; i++)
            {
                Initial_Particles[i] = new PixelParticle()
                {
                    Color = color,
                    Seed = i,
                    Energy = energy,
                    Dimension = dimension,
                    Radius = radius,
                    X = init_x,
                    Y = init_y,
                };
            }

            List<PixelParticle> Emitter = new List<PixelParticle>();
            foreach (PixelParticle item in Initial_Particles)
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
        }
    }
}