using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace VN_Server_Console.AppServer.Order
{
    public class OrderTest
    {
        private string _accessToken;

        public OrderTest(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task SubmitOrder()
        {
            try
            {
                Console.WriteLine("SubmitOrder:");
                Console.WriteLine();

                using (var client = new HttpClient())
                {
                    // Setup HTTP client and request headers.
                    client.BaseAddress = new Uri("http://localhost:53427/");
                    //client.BaseAddress = new Uri("http://vnapp-polymorph.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // Send POST request.
                    APIType_Order apiOrder = new APIType_Order();
                    apiOrder.OrderId = "0fe46dd7-3245-4454-95e7-748c4278e834"; // must exist in database...
                    apiOrder.FirstName = "Test 10";
                    apiOrder.LastName = "Test 10";
                    apiOrder.Email = "buildbuilt@gmail.com";
                    apiOrder.MobilePhone = "0909990000";
                    apiOrder.CustomerId = "C08";
                         

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/order/submitquote", apiOrder);

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
