using IdealGas_Simulator.ViewModels.Basis;

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
            Drawing_Space_Object = new DrawingSpace(5120, 3200);
        }
    }
}