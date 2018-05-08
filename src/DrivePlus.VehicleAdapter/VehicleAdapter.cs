using System;
using DrivePlus.Contracts;
using System.Net;

namespace DrivePlus.VehicleAdapter
{
    public class VehicleAdapter : IVehicleAdapter
    {
        private readonly Uri _vehicleUri;

        public VehicleAdapter(Uri vehicleUri)
        {
            _vehicleUri = vehicleUri;
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

            request.Timeout = 30;

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
            throw new NotImplementedException();
        }
    }
}
