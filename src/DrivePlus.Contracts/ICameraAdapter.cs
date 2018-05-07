using System;
using System.Windows.Controls;

namespace DrivePlus.Contracts
{
    public interface ICameraAdapter
    {
        void Login(Uri camerUri, UserCredentials userCredentials);

        Grid GetCamerGrid();
    }
}
