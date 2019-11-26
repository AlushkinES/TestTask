using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestTask
{
    public class RestClient
    {
        private static string _path;
        private static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://www.onetwotrip.com/")
        };

        public RestClient()
        {
            _path = "_hotels/api/suggestRequest";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<HttpResponseMessage> GetItem(string query, string limits = "10", bool checkResponse = true)
        {
            var response = await client.GetAsync($"{_path}?query={query}&limit={limits}");
            if (checkResponse) 
                CheckResponse(response); 
            return response;
        }

        private static void CheckResponse(HttpResponseMessage message)
        {
            Assert.IsTrue(message.IsSuccessStatusCode, "Error with status code: " + message.StatusCode);
        }
    }
}