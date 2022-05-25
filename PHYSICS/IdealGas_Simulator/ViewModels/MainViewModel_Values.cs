using IdealGas_Simulator.Models;
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
    }
}