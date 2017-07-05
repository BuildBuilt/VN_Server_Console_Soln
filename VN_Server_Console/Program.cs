using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VN_Server_Console.AuthServer;
using VN_Server_Console.AppServer.Member;
using VN_Server_Console.AppServer.Message;
using VN_Server_Console.AppServer.App;
using VN_Server_Console.AppServer.Order;

namespace VN_Server_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "Authorization Server"

            LoginTest loginTest = new LoginTest();

            // Register: a direct test (real-life is called via the app server).
            //loginTest.Register().Wait();

            // Login:
            //Task<APIResponse_Auth> taskAuth = loginTest.Login();
            //APIResponse_Auth authResponse = taskAuth.Result;

            #endregion


            #region "App Server"

            // Auth Server.
            // This is a direct call to "auth server" to test the login.
            //Task<APIResponse_Auth> taskAuth = loginTest.Login();
            //APIResponse_Auth authResponse = taskAuth.Result;

            // Member.
            MemberTest memberManager = new MemberTest();
            memberManager.Register().Wait();

            // Messaging.
            //MessageTest messageTest = new MessageTest();
            //messageTest.Refresh().Wait();

            // App-Login.
            // This is specifically for anonymous login at app server.
            //AppTest appManager = new AppTest();
            //appManager.Login().Wait();


            // Order
            // need to login for both anonymous and authen APIs...
            //Task<APIResponse_Auth> taskAuth = loginTest.Login();
            //APIResponse_Auth authResponse = taskAuth.Result;
            //OrderTest orderTest = new OrderTest(authResponse.access_token);
            //orderTest.SubmitOrder().Wait();

            // error test...
            //AppTest appManager = new AppTest();
            //Task<APIResponse_App_Login> taskLogin = appManager.Login();
            //APIResponse_App_Login loginResponse = taskLogin.Result;
            //OrderTest orderTest = new OrderTest(loginResponse.access_token);
            //orderTest.SubmitOrder().Wait();

            #endregion


            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
