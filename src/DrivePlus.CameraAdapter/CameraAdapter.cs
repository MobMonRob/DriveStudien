using System;
using System.Windows;
using System.Windows.Forms.Integration;
using DrivePlus.Contracts;

namespace DrivePlus.CameraAdapter
{
    public class CameraAdapter : ICameraAdapter
    {
        private readonly System.Windows.Forms.WebBrowser _browser;

        public CameraAdapter(Uri cameraUri)
        {
            _browser = new System.Windows.Forms.WebBrowser
            {
                ScrollBarsEnabled = false,
                MinimumSize = new System.Drawing.Size(1900, 1100)
            };
            _browser.Navigate(cameraUri);
        }

        public UIElement GetCameraUiElement()
        {
            var host = new WindowsFormsHost
            {
                Child = _browser,
                IsEnabled = false
            };

            AdjustBrowserClipping();

            return host;
        }

        public void Login(UserCredentials userCredentials)
        {
            _browser.Document?.GetElementById("username")?.SetAttribute("value", userCredentials.Username);
            _browser.Document?.GetElementById("passwd")?.SetAttribute("value", userCredentials.Password);
            _browser.Document?.GetElementById("login_ok")?.InvokeMember("onclick");
        }

        private void AdjustBrowserClipping()
        {
            _browser.Top = -185;
            _browser.Left = -350;          
        }
    }
}
