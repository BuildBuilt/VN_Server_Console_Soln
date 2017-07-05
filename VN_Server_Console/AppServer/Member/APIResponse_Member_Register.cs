using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AppServer.Member
{
    public class APIResponse_Member_Register : APIResponse
    {
        public string Id { get; set; }

        public APIResponse_Member_Register()
        {
            Id = "";
        }
    }
}
