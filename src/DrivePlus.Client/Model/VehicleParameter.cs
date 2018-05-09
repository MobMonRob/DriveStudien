using System;

namespace DrivePlus.Client.Model
{
    public class VehicleParameter
    {
        public Uri VehicleUri { get; set; }

        public bool IsLightOn { get; set; }

        public double CurrentSpeed{ get; set; }

        public VehicleParameter(Uri vehicleUri)
        {
            VehicleUri = vehicleUri;
            InitializeValuesByDefault();
        }

        private void InitializeValuesByDefault()
        {
            IsLightOn = false;
            CurrentSpeed = 5.0d;
        }
    }
}
