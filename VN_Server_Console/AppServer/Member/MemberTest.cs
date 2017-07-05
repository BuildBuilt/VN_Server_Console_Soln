using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace VN_Server_Console.AppServer.Member
{
    public class MemberTest
    {
        public async Task Register()
        {
            try
            {
                Console.WriteLine("Register:");
                Console.WriteLine();

                using (var client = new HttpClient())
                {
                    // Setup HTTP client and request headers.
                    //client.BaseAddress = new Uri("http://localhost:53427/");
                    //client.BaseAddress = new Uri("http://vnapp-polymorph.azurewebsites.net/");
                    client.BaseAddress = new Uri("http://vnsteelapp.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // Send POST request.
                    // no longer used as of Mar 26, 2017.
                    //APIType_Member_Register memberRegistration = new APIType_Member_Register();
                    //memberRegistration.Email = "warut.lenavat@gmail.com";
                    //memberRegistration.Password = "Demo2017@";
                    //memberRegistration.ConfirmPassword = memberRegistration.Password;

                    APIType_Member_RegisterFCM memberRegistration = new APIType_Member_RegisterFCM();
                    memberRegistration.Email = "anonymous@appserver.com";
                    memberRegistration.Password = "Vnapp2017";
                    memberRegistration.ConfirmPassword = memberRegistration.Password;
                    // FCM specific...
                    //memberRegistration.DeviceId = "DEVICE-2002";
                    //memberRegistration.RegistrationId = "eGBilzTF49g:APA91bEFUONDVcleJAzvQOhL-GzT8Cdr6gHnppgtgcOjx4lYA3psmQNmxdFTkB3n4eVhPQchgfV6tM1E0ITo4o1wdjCMPem5Q5B1QGy2q5zj-wuDc6hp2G-2tq2tRW-mNO8-hjsSyCrf";
                    memberRegistration.DeviceId = "";
                    memberRegistration.RegistrationId = "";

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/member/register", memberRegistration);

                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    Console.WriteLine();

                    if (response.IsSuccessStatusCode)
                    {
                        APIResponse_Member_Register memberResponse = await response.Content.ReadAsAsync<APIResponse_Member_Register>();

                        Console.WriteLine("Member Id: " + memberResponse.Id);
                        Console.WriteLine();
                    }
                    else
                    {
                        // because our sample API provides structured error message, we know that there's
                        // error code and message here...
                        APIResponse errorResponse = await response.Content.ReadAsAsync<APIResponse>();
                        Console.WriteLine("Error Code: " + errorResponse.ErrorCode);
                        Console.WriteLine("Error Message: " + errorResponse.ErrorMessage);
                        Console.WriteLine();

                        // we just show you how to read entire response body here, this can be useful for debugging,
                        // as well as with other API where there's "no" structured error message...
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                        Console.WriteLine("");
                    }

                } // end using...

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


    }
}
