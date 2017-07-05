using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace VN_Server_Console.AuthServer
{
    public class LoginTest
    {
        public LoginTest()
        {
        }

        /// <summary>
        /// This method is to test directly with authorization server only! The real functionality is to register
        /// via app server.
        /// </summary>
        /// <returns></returns>
        public async Task Register()
        {
            try
            {
                HttpResponseMessage response = null;

                Console.WriteLine("Register...");
                Console.WriteLine();

                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    //string baselineURL = "http://localhost:51950/";
                    //string baselineURL = "http://vnauth-polymorph.azurewebsites.net/";
                    string baselineURL = "http://authserver-vnsteel.azurewebsites.net/";
                    client.BaseAddress = new Uri(baselineURL);

                    // Create test data.
                    var newMember = new APIType_User()
                    {
                        Email = "anonymous@appserver.com",
                        Password = "Vnapp2017",
                        ConfirmPassword = "Vnapp2017",
                    };

                    String urlPath = baselineURL + "api/Account/Register";
                    response = await client.PostAsJsonAsync(urlPath, newMember);


                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    Console.WriteLine();

                    if (response.IsSuccessStatusCode)
                    {

                    }
                    else
                    {
                        // standard API returns error in response body...
                        Console.WriteLine("Content:");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }

                } // end using...
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public async Task<APIResponse_Auth> Login()
        {
            try
            {
                Console.WriteLine("Login...");
                Console.WriteLine();

                APIResponse_Auth authResponse = new APIResponse_Auth();

                using (var client = new HttpClient())
                {
                    // set the base URI for HTTP requests...
                    string tokenEndpoint = "http://localhost:51950/token";
                    //string tokenEndpoint = "http://vnauth-polymorph.azurewebsites.net/token";
                    client.BaseAddress = new Uri(tokenEndpoint);

                    // set the Accept header to "application/json", which tells the server to send data in JSON format...
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP POST
                    // build content with "application/x-www-form-urlencoded" content type...
                    Dictionary<string, string> dictForm = new Dictionary<string, string>();
                    dictForm.Add("grant_type", "password");
                    dictForm.Add("username", "buildbuilt@gmail.com  ");
                    dictForm.Add("password", "Demo2016@");
                    var content = new FormUrlEncodedContent(dictForm);

                    // send POST method...             
                    HttpResponseMessage response = await client.PostAsync(tokenEndpoint, content);
                    authResponse.isAuthen = false; // make sure it defaults to "not" authen...

                    if (response.IsSuccessStatusCode)
                    {
                        //_authenResponse = await response.Content.ReadAsAsync<AuthenReponse>();
                        authResponse = await response.Content.ReadAsAsync<APIResponse_Auth>();

                        if (authResponse != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("access_token: " + authResponse.access_token);
                            Console.WriteLine();
                            Console.WriteLine("token_type: " + authResponse.token_type);
                            Console.WriteLine("expires_in: " + authResponse.expires_in);
                            Console.WriteLine("userName: " + authResponse.userName);
                            Console.WriteLine();

                            //throw new Exception("_authenResult is null...");
                            authResponse.access_token = authResponse.access_token;
                            authResponse.isAuthen = true;
                        }
                    }
                    else
                    {
                        // standard API returns error in response body...
                        Console.WriteLine("Content:");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());

                        authResponse.isAuthen = false;
                    }

                } // end using...


                return authResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
