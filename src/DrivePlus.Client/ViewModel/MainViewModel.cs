using DrivePlus.Client.Model;
using DrivePlus.Client.ViewModel.Base;

namespace DrivePlus.Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Vehicle _vehicle;
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                _vehicle = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            Vehicle = new Vehicle();
        }
    }
}
