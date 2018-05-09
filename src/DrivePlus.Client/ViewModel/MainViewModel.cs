using DrivePlus.Client.Model;
using DrivePlus.Client.ViewModel.Base;
using System;
using System.Windows;
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

        private bool _vehicleControl;
        public bool VehicleControl
        {
            get => _vehicleControl;
            set
            {
                _vehicleControl = value;
                RaisePropertyChanged();
            }
        }

        private bool _cameraControl;
        public bool CameraControl
        {
            get => _cameraControl;
            set
            {
                _cameraControl = value;
                RaisePropertyChanged();
            }
        }

        public ConnectModel ConnectModel { get; set; }

        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand MagicCommand { get; set; }

        public Grid StreamGrid { get; set; }
        public UIElement ConnectionMask { get; set; }

        public MainViewModel()
        {
            ConnectModel = new ConnectModel();
            ConnectCommand = new RelayCommand(ConnectCommandExecute, ConnectCommandCanExecute);
            MagicCommand = new RelayCommand(MagicCommandExecute, MagicCommandCanExecute);

            VehicleControl = true; // default
            CameraControl = false;
        }

        private void ConnectCommandExecute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;

            Vehicle = new Vehicle(new Uri("http://" + ConnectModel.VehicleIpTextValue + ":" + ConnectModel.VehiclePortTextValue));
            Camera = new Camera(new Uri("http://" + ConnectModel.CameraIpTextValue + ":" + ConnectModel.CameraPortTextValue),
                ConnectModel.CameraUsernameTextValue, passwordBox?.Password);

            GetCameraStream();
        }

        private bool ConnectCommandCanExecute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;

            if (string.IsNullOrEmpty(ConnectModel.VehicleIpTextValue) || string.IsNullOrEmpty(ConnectModel.VehiclePortTextValue)
                || string.IsNullOrEmpty(ConnectModel.CameraIpTextValue) || string.IsNullOrEmpty(ConnectModel.CameraPortTextValue)
                || string.IsNullOrEmpty(ConnectModel.CameraUsernameTextValue) || string.IsNullOrEmpty(passwordBox?.Password))
            {
                return false;
            }

            return true;
        }

        private void GetCameraStream()
        {
            ConnectionMask.IsHitTestVisible = false;
            StreamGrid.Children.Add(Camera.CameraAdapter.GetCameraUiElement());
        }

        private void MagicCommandExecute(object parameter)
        {
            Camera?.CameraAdapter.Login(Camera.Parameter.UserCredentials);
            Vehicle?.VehicleAdapter.Fetch();
        }

        private bool MagicCommandCanExecute(object parameter)
        {
            return true;
        }
    }
}
