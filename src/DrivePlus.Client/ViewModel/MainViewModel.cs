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

        private Camera _camera;
        public Camera Camera
        {
            get => _camera;
            set
            {
                _camera = value;
                RaisePropertyChanged();
            }
        }
        
        public RelayCommand ConnectCommand { get; set; }

        public MainViewModel()
        {
            ConnectCommand = new RelayCommand(ConnectCommandExecute, ConnectCommandCanExecute);
        }

        private void ConnectCommandExecute(object parameter)
        {

        }

        private bool ConnectCommandCanExecute(object parameter)
        {
            return true;
        }
    }
}
