using IdentityModel;
using IdentityModel.Client;
using System;
using System.Net.Http;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenclient = new TokenClient("http://localhost:5000", "lingdu", "41223EDC");
            var token = tokenclient.RequestClientCredentialsAsync("api1").Result;

            var client = new HttpClient();
           
            client.SetBearerToken(token.AccessToken);
            var result = client.GetStringAsync("http://localhost:5000/test").Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
