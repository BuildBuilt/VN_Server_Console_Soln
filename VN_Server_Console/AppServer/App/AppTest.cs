using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace VN_Server_Console.AppServer.App
{
    public class AppTest
    {
        public AppTest()
        {

        }

        public async Task<APIResponse_App_Login> Login()
        {
            try
            {
                Console.WriteLine("Login:");
                Console.WriteLine();

                APIResponse_App_Login logResponse = new APIResponse_App_Login();

                using (var client = new HttpClient())
                {
                    // Setup HTTP client and request headers.
                    client.BaseAddress = new Uri("http://localhost:53427/");
                    //client.BaseAddress = new Uri("http://vnapp-polymorph.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // Send POST request.
                    APIType_App_Login login = new APIType_App_Login();
                    login.AppKey = "FF0A7FD2-5E7A-44D6-9F6D-5BA023E47FDC";

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/app/login", login);

                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    Console.WriteLine();

                    if (response.IsSuccessStatusCode)
                    {
                        logResponse = await response.Content.ReadAsAsync<APIResponse_App_Login>();

                        Console.WriteLine("access_token: " + logResponse.access_token);
                        Console.WriteLine("token_type: " + logResponse.token_type);
                        Console.WriteLine("expires_in: " + logResponse.expires_in);
                        Console.WriteLine();

                        logResponse.isAuthen = true;
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

                        logResponse.isAuthen = false;
                    }

                } // end using...


                return logResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw ex;
            }
        }

    }
}
