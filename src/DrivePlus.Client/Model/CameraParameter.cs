using System;

namespace DrivePlus.Client.Model
{
    public class CameraParameter
    {
        public Uri CameraUri { get; set; }

        public UserCredentials UserCredentials { get; set; }
        
        public CameraParameter(Uri cameraUri, string username, string password)
        {
            CameraUri = cameraUri;
            UserCredentials = new UserCredentials(username, password);
        }
    }
}
