using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AppServer.App
{
    public class APIResponse_App_Login : APIResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public APIResponse_App_Login()
        {
            access_token = "";
            token_type = "";
            expires_in = "";
        }

    }
}
