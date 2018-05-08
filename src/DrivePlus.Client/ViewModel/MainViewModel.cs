using DrivePlus.Client.Model;
using DrivePlus.Client.ViewModel.Base;
using System;
using System.Windows.Controls;

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

        public ConnectModel ConnectModel { get; set; }

        public RelayCommand ConnectCommand { get; set; }

        public MainViewModel()
        {
            ConnectModel = new ConnectModel();
            ConnectCommand = new RelayCommand(ConnectCommandExecute, ConnectCommandCanExecute);
        }

        private void ConnectCommandExecute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;

            Vehicle = new Vehicle(new Uri("http://" + ConnectModel.VehicleIpTextValue + ":" + ConnectModel.VehiclePortTextValue));
            Camera = new Camera(new Uri("http://" + ConnectModel.CameraIpTextValue + ":" + ConnectModel.CameraPortTextValue),
                ConnectModel.CameraUsernameTextValue, passwordBox?.Password);
        }

        private bool ConnectCommandCanExecute(object parameter)
        {
            return true;
        }
    }
}
