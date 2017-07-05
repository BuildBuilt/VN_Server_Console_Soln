using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Server_Console.AppServer.Order
{
    public class APIType_Order
    {
        public string OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string CustomerId { get; set; }
       // public List<APIType_Order_Product> OrderProducts { get; set; }


        public APIType_Order()
        {
            //Order
            //OrderProducts = new List<APIType_Order_Product>();
            OrderId = "";
            FirstName = "";
            LastName = "";
            Email = "";
            MobilePhone = "";
            CustomerId = "";
        }
    }
}
