using IdealGas_Simulator.ViewModels.Basis;
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
    }
}