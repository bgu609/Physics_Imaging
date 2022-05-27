using IdealGas_Simulator___OpenGL_.ViewModels;
using System.Windows;

namespace IdealGas_Simulator___OpenGL_.Views
{
    /// <summary>
    /// ShellView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : Window
    {
        MainViewModel MainViewModel;

        public ShellView()
        {
            InitializeComponent();

            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;
        }
    }
}