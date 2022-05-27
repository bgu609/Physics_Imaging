using IdealGas_Simulator.ViewModels.Basis;
using System;
using System.Threading;
using System.Windows.Threading;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public DispatcherTimer Drawing_Timer;

        // WriteableBitmap : 결국 CPU를 이용하는 것이기 때문에 한계점이 있음
        private DrawingSpace drawing_space_object;
        public  DrawingSpace Drawing_Space_Object
        {
            get => drawing_space_object;
            set { drawing_space_object = value;  }
        }



        public MainViewModel()
        {
            Initialize_UI();

            Initialize();
        }



        private void Initialize()
        {
            Number_of_Particles = 30000;
            Pixel_Particles_Energy = 20;



            Drawing_Timer = new DispatcherTimer();
            Drawing_Timer.Interval = TimeSpan.FromMilliseconds(10);
            Drawing_Timer.Tick += Drawing_Timer_Tick;

            Simulation_Thread = new Thread(Simulation_Loop);
            Simulation_Thread.IsBackground = true;

            Drawing_Timer.Start();
            Simulation_Thread.Start();
        }

        private void Initialize_UI()
        {
            Drawing_Space_Object = new DrawingSpace(2400, 1500);
        }

        private void Drawing_Timer_Tick(object sender, EventArgs e)
        {
            Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
        }
    }
}