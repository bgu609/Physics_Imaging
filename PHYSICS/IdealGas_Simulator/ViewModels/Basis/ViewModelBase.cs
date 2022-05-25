using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IdealGas_Simulator.ViewModels.Basis
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}