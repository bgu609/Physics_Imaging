using IdealGas_Simulator.Models;
using IdealGas_Simulator.ViewModels.Basis;
using System;
using System.Windows.Input;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel
    {
        private ICommand add_particle_command;
        public ICommand Add_Particle_Command
        {
            get => add_particle_command ?? (add_particle_command = new RelayCommand<object>(o => Add_Particle()));
        }
        private void Add_Particle()
        {

        }



        public void Invoke_Probability_Position(PixelParticle Particle)
        {
            if (Particle == null) return;

            if (Particle.Dimension == 1)
            {

            }
            else if (Particle.Dimension == 2)
            {
                Quantum_Handler = new Random((int)DateTime.Now.Ticks + Particle.Seed);

                double Move_Radial = Quantum_Handler.Next(-Particle.Energy, Particle.Energy + 1);
                double Move_Radial_Decimal = Quantum_Handler.NextDouble();
                int Move_Radius_Decimal_Sign = Quantum_Handler.Next(0, 2);

                double Move_Azimuth = Quantum_Handler.Next(0, 361);
                double Move_Azimuth_Decimal = Quantum_Handler.NextDouble();
                int Move_Azimuth_Decimal_Sign = Quantum_Handler.Next(0, 2);

                Move_Radial += (double)(Move_Radial_Decimal * ((Move_Radius_Decimal_Sign == 1) ? 1 : -1));
                Move_Azimuth += (double)(Move_Azimuth_Decimal * ((Move_Azimuth_Decimal_Sign == 1) ? 1 : -1));

                // 일단 귀찮으니 사사오입 반올림 사용
                Particle.X += (int)Math.Round(Move_Radial * Math.Sin(Move_Azimuth));
                Particle.Y += (int)Math.Round(Move_Radial * Math.Cos(Move_Azimuth));

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