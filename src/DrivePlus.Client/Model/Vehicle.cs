namespace DrivePlus.Client.Model
{
    public class Vehicle
    {
        public VehicleParameter Parameter { get; set; }

        public Vehicle()
        {
            Parameter = new VehicleParameter();
        }
    }
}
