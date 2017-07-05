using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AppServer.Member
{
    class APIType_Member_RegisterFCM : APIType_Member_Register
    {
        // These are fields required during registration from client app. There are two more
        // fields required by FCM Service: "MemberId" and "IsMember" flag; however, these
        // additional fields are provided by app server.
        public string DeviceId { get; set; }

        public string RegistrationId { get; set; }

        public APIType_Member_RegisterFCM()
        {
            DeviceId = "";
            RegistrationId = "";
        }
    }
}
