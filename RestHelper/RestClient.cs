using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RestHelper
{
    public class RestClient : IDisposable
    {
        private string _path;
        private HttpClient client = new HttpClient();

        public RestClient(string baseAddress, string path = "", bool redirection = true)
        {
            client = new HttpClient(new HttpClientHandler {AllowAutoRedirect = redirection})
            {
                BaseAddress = new Uri(baseAddress),
            };
            _path = path;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetRequest()
        {
            return await client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetHotels(string query, string limits = "5", string additionalQuery = "", bool checkResponse = true)
        {
            var response = await client.GetAsync($"{_path}?query={query}{additionalQuery}&limit={limits}");
            if (checkResponse) 
                CheckResponse(response); 
            return response;
        }

        private static void CheckResponse(HttpResponseMessage message)
        {
            Assert.IsTrue(message.IsSuccessStatusCode, "Error with status code: " + message.StatusCode);
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}