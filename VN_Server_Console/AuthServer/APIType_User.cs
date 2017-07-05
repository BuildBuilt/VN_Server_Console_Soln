using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AuthServer
{
    public class APIType_User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public APIType_User()
        {
            Email = "";
            Password = "";
            ConfirmPassword = "";
        }
    }
}
