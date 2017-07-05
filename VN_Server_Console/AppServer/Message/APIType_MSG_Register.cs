using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AppServer.Message
{
    public class APIType_MSG_Register
    {
        public string DeviceId { get; set; }
        public string MemberId { get; set; }
        public bool IsMember { get; set; }
        public string RegistrationId { get; set; }

        public APIType_MSG_Register()
        {
            DeviceId = "";
            MemberId = "";
            IsMember = false;
            RegistrationId = "";
        }
    }
}
