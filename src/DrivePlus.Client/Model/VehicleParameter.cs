namespace DrivePlus.Client.Model
{
    public class VehicleParameter
    {
        public bool IsLightOn { get; set; }

        public VehicleParameter()
        {
            InitializeValuesByDefault();
        }

        private void InitializeValuesByDefault()
        {
            IsLightOn = false;
        }
    }
}
