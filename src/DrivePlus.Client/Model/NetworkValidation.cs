using System;
using System.Linq;

namespace DrivePlus.Client.Model
{
    public class NetworkValidation
    {
        public static bool ValidateIp(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }

            string[] splitValues = ip.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out var n));
        }

        public static bool ValidatePort(string port)
        {
            int n;
            if (int.TryParse(port, out n))
            {
                if (n >= 0 && n <= 65535)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
