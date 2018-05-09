using System;
using DrivePlus.Contracts;

namespace DrivePlus.Client.Model
{
    public class Camera
    {
        public CameraParameter Parameter { get; set; }

        public ICameraAdapter CameraAdapter { get; set; }

        public Camera(Uri cameraUri, string username, string password)
        {
            Parameter = new CameraParameter(cameraUri, username, password);
            CameraAdapter = new CameraAdapter.CameraAdapter(cameraUri);
        }
    }
}
