using System;

namespace DrivePlus.Client.Model
{
    public class Camera
    {
        public CameraParameter Parameter { get; set; }

        public Camera(Uri cameraUri, string username, string password)
        {
            Parameter = new CameraParameter(cameraUri, username, password);
        }
    }
}
