using DrivePlus.Client.ViewModel;
using DrivePlus.Contracts;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace DrivePlus.Client.View
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            viewModel.StreamGrid = StreamGrid;
            viewModel.ConnectionMask = ConnectionPanel;
            DataContext = viewModel;

            var descriptor = DependencyPropertyDescriptor.FromProperty(System.Windows.Controls.Primitives.ButtonBase.IsPressedProperty, typeof(Button));
            descriptor.AddValueChanged(UpButton, ButtonPropertyChanged);
            descriptor.AddValueChanged(LeftButton, ButtonPropertyChanged);
            descriptor.AddValueChanged(RightButton, ButtonPropertyChanged);
            descriptor.AddValueChanged(DownButton, ButtonPropertyChanged);
        }

        private void ButtonPropertyChanged(object sender, EventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            var button = sender as Button;

            if (button?.IsPressed == false)
            {
                viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Stop);
            }
            else
            {
                if (button?.Name == "UpButton" && button?.IsPressed == true)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Forward);
                }
                else if (button?.Name == "LeftButton" && button?.IsPressed == true)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Left);
                }
                else if (button?.Name == "RightButton" && button?.IsPressed == true)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Right);
                }
                else if (button?.Name == "DownButton" && button?.IsPressed == true)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Backward);
                }
            }
        }

        private void LightButtonChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.SwitchLightOn);
        }

        private void LightButtonUnchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.SwitchLightOff);
        }

        private void SpeedValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            var viewModel = DataContext as MainViewModel;
            var slider = sender as Slider;
            viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.SetSpeed, Convert.ToInt32(slider?.Value));
        }
    }
}
