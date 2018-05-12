using DrivePlus.Client.Model;
using DrivePlus.Client.View;
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
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand FetchDistanceCommand { get; set; }
        public RelayCommand ShowDistanceCommand { get; set; }
        public RelayCommand SnapshotCommand { get; set; }

        public Grid StreamGrid { get; set; }
        public UIElement ConnectionMask { get; set; }

        public MainViewModel()
        {
            ConnectModel = new ConnectModel();
            ConnectCommand = new RelayCommand(ConnectCommandExecute, ConnectCommandCanExecute);
            LoginCommand = new RelayCommand(LoginCommandExecute, LoginCommandCanExecute);
            FetchDistanceCommand = new RelayCommand(FetchDistanceCommandExecute, FetchDistanceCommandCanExecute);
            ShowDistanceCommand = new RelayCommand(ShowDistanceCommandExecute, ShowDistanceCommandCanExecute);
            SnapshotCommand = new RelayCommand(SnapshotCommandExecute, SnapshotCommandCanExecute);

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

            if (NetworkValidation.ValidateIp(ConnectModel.VehicleIpTextValue) && NetworkValidation.ValidateIp(ConnectModel.CameraIpTextValue)
                && NetworkValidation.ValidatePort(ConnectModel.VehiclePortTextValue) && NetworkValidation.ValidatePort(ConnectModel.CameraPortTextValue)
                && string.IsNullOrEmpty(ConnectModel.CameraUsernameTextValue) == false && string.IsNullOrEmpty(passwordBox?.Password) == false)
            {
                return true;
            }

            return false;
        }

        private void GetCameraStream()
        {
            ConnectionMask.IsHitTestVisible = false;
            StreamGrid.Children.Add(Camera.CameraAdapter.GetCameraUiElement());
        }

        private void LoginCommandExecute(object parameter)
        {
            Camera?.CameraAdapter.Login(Camera.Parameter.UserCredentials);
        }

        private bool LoginCommandCanExecute(object parameter)
        {
            if (Camera == null)
            {
                return false;
            }

            return true;
        }

        private void FetchDistanceCommandExecute(object parameter)
        {
            Vehicle?.VehicleAdapter.FetchDistance();
        }

        private bool FetchDistanceCommandCanExecute(object parameter)
        {
            if (Vehicle == null)
            {
                return false;
            }

            return true;
        }

        private void ShowDistanceCommandExecute(object parameter)
        {
            MessageBox.Show("Abstand: " + Vehicle?.VehicleAdapter.GetDistance() + " cm", "Abstand in Fahrtrichtung");
        }

        private bool ShowDistanceCommandCanExecute(object parameter)
        {
            if (Vehicle == null)
            {
                return false;
            }

            return true;
        }

        private void SnapshotCommandExecute(object parameter)
        {
            new SnapshotView(Camera?.CameraAdapter.GetSnapshotUri(Camera?.Parameter.UserCredentials)).ShowDialog(); ;
        }

        private bool SnapshotCommandCanExecute(object parameter)
        {
            if (Camera == null)
            {
                return false;
            }

            return true;
        }
    }
}
