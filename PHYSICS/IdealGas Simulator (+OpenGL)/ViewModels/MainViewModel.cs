using IdealGas_Simulator___OpenGL_.ViewModels.Basis;
using OpenGL_CLR;

namespace IdealGas_Simulator___OpenGL_.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        OpenGL_Lib GL_Lib;



        public MainViewModel()
        {
            GL_Lib = new OpenGL_Lib();

            double sum = GL_Lib.Sum(1, 2);
            sum = GL_Lib.Sum(2, 3);
        }
    }
}