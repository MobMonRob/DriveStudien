namespace DrivePlus.Client.Model
{
    public class Camera
    {
        public CameraParameter Parameter { get; set; }

        public Camera()
        {
            Parameter = new CameraParameter();
        }
    }
}
