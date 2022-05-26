using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel
    {
        private List<PixelParticle> pixel_particles;
        public List<PixelParticle> Pixel_Particles
        {
            get => pixel_particles;
            set { pixel_particles = value; }
        }

        private Random quantum_handler;
        public Random Quantum_Handler
        {
            get => quantum_handler;
            set { quantum_handler = value; }
        }



        #region [[ Boundary Condition ]]

        private int x_boundary_min;
        public int X_Boundary_Min
        {
            get => x_boundary_min;
            set { x_boundary_min = value; OnChanged(); }
        }

        private int x_boundary_max;
        public int X_Boundary_Max
        {
            get => x_boundary_max;
            set { x_boundary_max = value; OnChanged(); }
        }

        private int y_boundary_min;
        public int Y_Boundary_Min
        {
            get => y_boundary_min;
            set { y_boundary_min = value; OnChanged(); }
        }

        private int y_boundary_max;
        public int Y_Boundary_Max
        {
            get => y_boundary_max;
            set { y_boundary_max = value; OnChanged(); }
        }

        private int z_boundary_min;
        public int Z_Boundary_Min
        {
            get => z_boundary_min;
            set { z_boundary_min = value; OnChanged(); }
        }

        private int z_boundary_max;
        public int Z_Boundary_Max
        {
            get => z_boundary_max;
            set { z_boundary_max = value; OnChanged(); }
        }

        #endregion



        public void Invoke_Probability_Position(PixelParticle Particle)
        {
            if (Particle == null) return;

            if (Particle.Dimension == 1)
            {

            }
            else if (Particle.Dimension == 2)
            {
                Quantum_Handler = new Random((int)DateTime.Now.Ticks + Particle.Seed);

                double Move_Radius = Quantum_Handler.Next(-Particle.Entropy, Particle.Entropy + 1);
                double Move_Radius_Decimal = Quantum_Handler.NextDouble();
                int Move_Radius_Decimal_Sign = Quantum_Handler.Next(0, 2);

                double Move_Azimuth = Quantum_Handler.Next(0, 361);
                double Move_Azimuth_Decimal = Quantum_Handler.NextDouble();
                int Move_Azimuth_Decimal_Sign = Quantum_Handler.Next(0, 2);

                Move_Radius += (double)(Move_Radius_Decimal * ((Move_Radius_Decimal_Sign == 1) ? 1 : -1));
                Move_Azimuth += (double)(Move_Azimuth_Decimal * ((Move_Azimuth_Decimal_Sign == 1) ? 1 : -1));

                // 일단 귀찮으니 사사오입 반올림 사용
                Particle.X += (int)Math.Round(Move_Radius * Math.Sin(Move_Azimuth));
                Particle.Y += (int)Math.Round(Move_Radius * Math.Cos(Move_Azimuth));

                if (Particle.X < X_Boundary_Min)
                {
                    Particle.X = X_Boundary_Min;
                }
                else if (Particle.X > X_Boundary_Max)
                {
                    Particle.X = X_Boundary_Max;
                }

                if (Particle.Y < Y_Boundary_Min)
                {
                    Particle.Y = Y_Boundary_Min;
                }
                else if (Particle.Y > Y_Boundary_Max)
                {
                    Particle.Y = Y_Boundary_Max;
                }
            }
            else if (Particle.Dimension == 3)
            {

            }
        }
    }
}