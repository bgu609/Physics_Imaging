﻿using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel
    {
        private Random quantum_handler;
        public Random Quantum_Handler
        {
            get => quantum_handler;
            set { quantum_handler = value; }
        }

        private List<PixelParticle> pixel_particles;
        public List<PixelParticle> Pixel_Particles
        {
            get => pixel_particles;
            set { pixel_particles = value; }
        }

        private int number_of_particles = 10000;
        public int Number_of_Particles
        {
            get => number_of_particles;
            set { number_of_particles = value; }
        }



        #region [[ Boundary Condition ]]

        private int pixel_particles_energy = 10;
        public int Pixel_Particles_Energy
        {
            get => pixel_particles_energy;
            set { pixel_particles_energy = value; }
        }

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
    }
}