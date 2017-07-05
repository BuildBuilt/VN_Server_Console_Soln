using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace VN_Server_Console.AppServer.Message
{
    public class MessageTest
    {
        public async Task Refresh()
        {
            try
            {
                Console.WriteLine("Refresh:");
                Console.WriteLine();

                using (var client = new HttpClient())
                {
                    // Setup HTTP client and request headers.
                    //client.BaseAddress = new Uri("http://localhost:53427/");
                    client.BaseAddress = new Uri("http://vnapp-polymorph.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // Send POST request.

                    #region "Create New - Non-Member"

                    APIType_MSG_Register registration = new APIType_MSG_Register();
                    registration.DeviceId = "DEVICE-4001";
                    registration.MemberId = "";
                    registration.IsMember = false;
                    registration.RegistrationId = "eGBilzTF49g:APA91bEFUONDVcleJAzvQOhL-GzT8Cdr6gHnppgtgcOjx4lYA3psmQNmxdFTkB3n4eVhPQchgfV6tM1E0ITo4o1wdjCMPem5Q5B1QGy2q5zj-wuDc6hp2G-2tq2tRW-mNO8-hjsSyCrf";

                    #endregion

                    #region "Create New - Member"
                    // this is for use case where app requires "member registration"...

                    //APIType_MSG_Register registration = new APIType_MSG_Register();
                    //registration.DeviceId = "DEVICE-1002";
                    //registration.MemberId = "FA34267E-F759-40F9-A85E-4F222920B3FB";
                    //registration.IsMember = true;
                    //registration.RegistrationId = "eGBilzTF49g:APA91bEFUONDVcleJAzvQOhL-GzT8Cdr6gHnppgtgcOjx4lYA3psmQNmxdFTkB3n4eVhPQchgfV6tM1E0ITo4o1wdjCMPem5Q5B1QGy2q5zj-wuDc6hp2G-2tq2tRW-mNO8-hjsSyCrf";

                    #endregion

                    #region "Update - Non-Member"
                    // for example, install and unstall without ever register...

                    //APIType_MSG_Register registration = new APIType_MSG_Register();
                    //registration.DeviceId = "DEVICE-1001";
                    //registration.MemberId = "";
                    //registration.IsMember = false;
                    //registration.RegistrationId = "fn1RiYxu_nE:APA91bEvbSubB8pySLT7Q3vgZZjwRI7OLOEaT_twicGCBehEQ_wlThp78Yu6r6Y17fs5z4P79rjmnDRDS90VaT5vg5bAyiHbGDRn3Tyerh9500Qmpop08ZJuuBSOjrmwRSz5mPZvLQXF";

                    #endregion

                    #region "Update - Member"
                    // token refresh, multi-user...

                    //APIType_MSG_Register registration = new APIType_MSG_Register();
                    //registration.DeviceId = "DEVICE-1002";
                    //registration.MemberId = "FA34267E-F759-40F9-A85E-4F222920B3FB";
                    //registration.IsMember = true;
                    //registration.RegistrationId = "fn1RiYxu_nE:APA91bEvbSubB8pySLT7Q3vgZZjwRI7OLOEaT_twicGCBehEQ_wlThp78Yu6r6Y17fs5z4P79rjmnDRDS90VaT5vg5bAyiHbGDRn3Tyerh9500Qmpop08ZJuuBSOjrmwRSz5mPZvLQXF";

                    #endregion


                    HttpResponseMessage response = await client.PostAsJsonAsync("api/message/refresh", registration);

                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    Console.WriteLine();

                    if (response.IsSuccessStatusCode)
                    {
                        APIResponse registerResponse = await response.Content.ReadAsAsync<APIResponse>();
                        Console.WriteLine("Response Status: " + registerResponse.Success);
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
