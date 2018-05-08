using System;

namespace DrivePlus.Client.Model
{
    public class Vehicle
    {
        public VehicleParameter Parameter { get; set; }

        public Vehicle(Uri vehicleUri)
        {
            Parameter = new VehicleParameter(vehicleUri);
        }
    }
}
