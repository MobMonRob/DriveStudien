using System.Windows.Forms.Integration;

namespace DrivePlus.Contracts
{
    public interface ICameraAdapter
    {
        void Login(UserCredentials userCredentials);

        WindowsFormsHost GetCameraHost();
    }
}
