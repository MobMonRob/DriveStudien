using System;
using DrivePlus.Contracts;

namespace DrivePlus.Client.Model
{
    public class Vehicle
    {
        public VehicleParameter Parameter { get; set; }

        public IVehicleAdapter VehicleAdapter { get; set; }

        public Vehicle(Uri vehicleUri)
        {
            Parameter = new VehicleParameter(vehicleUri);
            VehicleAdapter = new VehicleAdapter.VehicleAdapter(vehicleUri);
        }
    }
}
