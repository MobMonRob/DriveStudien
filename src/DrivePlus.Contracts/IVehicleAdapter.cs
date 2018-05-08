namespace DrivePlus.Contracts
{
    public interface IVehicleAdapter
    {
        void SendCommand(VehicleCommand command, int value = 0);
    }
}
