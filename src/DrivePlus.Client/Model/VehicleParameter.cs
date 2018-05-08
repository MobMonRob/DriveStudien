using System;

namespace DrivePlus.Client.Model
{
    public class VehicleParameter
    {
        public bool IsLightOn { get; set; }
        public Uri VehicleUri { get; set; }

        public VehicleParameter(Uri vehicleUri)
        {
            InitializeValuesByDefault();
            VehicleUri = vehicleUri;
        }

        private void InitializeValuesByDefault()
        {
            IsLightOn = false;
        }
    }
}
