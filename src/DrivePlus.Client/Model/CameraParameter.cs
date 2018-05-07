using System;

namespace DrivePlus.Client.Model
{
    public class CameraParameter
    {
        public Uri CameraUri { get; set; }

        public CameraParameter()
        {
            InitializeValuesByDefault();
        }

        private void InitializeValuesByDefault()
        {
            CameraUri = new Uri("");
        }
    }
}
