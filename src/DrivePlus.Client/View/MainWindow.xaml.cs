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
                if (UpButton.IsPressed)
                {                   
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Forward);
                }
                else if (LeftButton.IsPressed)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Left);
                }
                else if (RightButton.IsPressed)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Right);
                }
                else if (DownButton.IsPressed)
                {
                    viewModel?.Vehicle?.VehicleAdapter.SendCommand(VehicleCommand.Backward);
                }
            }
        }
    }
}
