using System.Windows;

namespace DrivePlus.Contracts
{
    public interface ICameraAdapter
    {
        void Login(UserCredentials userCredentials);

        UIElement GetCameraUiElement();
    }
}
