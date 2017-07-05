using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console
{
    public class APIResponse
    {
        public bool isAuthen { get; set; }
        public bool Success { get; set; }
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }

        public APIResponse()
        {
            isAuthen = false;
            Success = false;
            ErrorCode = "";
            ErrorMessage = "";
        }
    }
}
