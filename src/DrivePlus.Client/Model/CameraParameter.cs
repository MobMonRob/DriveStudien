using System.Net;

namespace DrivePlus.Client.Model
{
    public class CameraParameter
    {
        public IPAddress IpAddress { get; set; }

        public CameraParameter()
        {
            InitializeValuesByDefault();
        }

        private void InitializeValuesByDefault()
        {
            IpAddress = IPAddress.None;
        }
    }
}
