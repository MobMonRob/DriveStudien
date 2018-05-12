using System;
using System.Windows;

namespace DrivePlus.Contracts
{
    public interface ICameraAdapter
    {
        void Login(UserCredentials userCredentials);

        UIElement GetCameraUiElement();

        void SendCommand(UserCredentials userCredentials, CameraCommand command, int value = 0);

        Uri GetSnapshotUri(UserCredentials userCredentials);
    }
}
