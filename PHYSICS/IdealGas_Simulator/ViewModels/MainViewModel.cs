using IdealGas_Simulator.Models;
using IdealGas_Simulator.ViewModels.Basis;
using System.Collections.Generic;
using System.Threading;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private DrawingSpace drawing_space_object;
        public  DrawingSpace Drawing_Space_Object
        {
            get => drawing_space_object;
            set { drawing_space_object = value;  }
        }



        public MainViewModel()
        {
            Drawing_Space_Object = new DrawingSpace(2400, 1500);
            Pixel_Particles = new List<PixelParticle>();

            Simulation_Thread = new Thread(Simulation_Loop);
            Simulation_Thread.IsBackground = true;
            Simulation_Thread.Start();
        }
    }
}