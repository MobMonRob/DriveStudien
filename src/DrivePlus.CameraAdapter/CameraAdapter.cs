using System;
using System.Net;
using System.Windows;
using System.Windows.Forms.Integration;
using DrivePlus.Contracts;

namespace DrivePlus.CameraAdapter
{
    public class CameraAdapter : ICameraAdapter
    {
        private readonly System.Windows.Forms.WebBrowser _browser;
        private readonly Uri _cameraUri;

        public CameraAdapter(Uri cameraUri)
        {
            _cameraUri = cameraUri;

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

        public void SendCommand(UserCredentials userCredentials, CameraCommand command, int value = 0)
        {
            WebRequest request;

            switch (command)
            {
                case (CameraCommand.Stop):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=ptzStopRun&usr=" 
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.Up):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=ptzMoveUp&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.Down):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=ptzMoveDown&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.Left):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=ptzMoveLeft&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.Right):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=ptzMoveRight&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.SwitchInfraLedOn):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=openInfraLed&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.SwitchInfraLedOff):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=closeInfraLed&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                case (CameraCommand.SetBrightness):
                    request = WebRequest.Create(_cameraUri + "cgi-bin/CGIProxy.fcgi?cmd=setBrightness&brightness=" + value + "&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
                    break;
                default:
                    return;
            }

            request.GetResponse();
            request.Abort();
        }

        public Uri GetSnapshotUri(UserCredentials userCredentials)
        {
            return new Uri(_cameraUri + "/cgi-bin/CGIProxy.fcgi?cmd=snapPicture2&usr="
                        + userCredentials.Username + "&pwd=" + userCredentials.Password);
        }
    }
}
