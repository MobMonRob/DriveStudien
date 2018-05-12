using System;
using DrivePlus.Contracts;
using System.Net;

namespace DrivePlus.VehicleAdapter
{
    public class VehicleAdapter : IVehicleAdapter
    {
        private readonly Uri _vehicleUri;

        private readonly System.Windows.Forms.WebBrowser _browser;

        public VehicleAdapter(Uri vehicleUri)
        {
            _vehicleUri = vehicleUri;
            _browser = new System.Windows.Forms.WebBrowser();
        }

        public void SendCommand(VehicleCommand command, int value = 0)
        {
            WebRequest request;
            
            switch (command)
            {
                case (VehicleCommand.Stop):
                    request = WebRequest.Create(_vehicleUri + "stop");
                    break;
                case (VehicleCommand.Forward):
                    request = WebRequest.Create(_vehicleUri + "forward");
                    break;
                case (VehicleCommand.Backward):
                    request = WebRequest.Create(_vehicleUri + "backward");
                    break;
                case (VehicleCommand.Left):
                    request = WebRequest.Create(_vehicleUri + "left");
                    break;
                case (VehicleCommand.Right):
                    request = WebRequest.Create(_vehicleUri + "right");
                    break;
                case (VehicleCommand.SwitchLightOn):
                    request = WebRequest.Create(_vehicleUri + "light_on");
                    break;
                case (VehicleCommand.SwitchLightOff):
                    request = WebRequest.Create(_vehicleUri + "light_off");
                    break;
                case (VehicleCommand.SetSpeed):
                    request = WebRequest.Create(_vehicleUri + "set_speed=" + value);
                    break;
                default:
                    return;
            }

            request.Timeout = 300;

            try
            {
                request.GetResponse();
            }
            catch (Exception)
            {
                Console.WriteLine("Command sent");
            }
        }

        public string GetDistance()
        {
            return Convert.ToInt32(_browser.DocumentText).ToString();
        }

        public void FetchDistance()
        {
            _browser.Navigate(_vehicleUri + "get_distance");
        }
    }
}
