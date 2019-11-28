using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tests.Models;
using RestHelper;

namespace Tests
{
    [Timeout(10000)]
    [TestFixture]
    [Category("Category")]
    public class GetHotelTests
    {
        private RestClient _restClient;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _restClient = new RestClient("https://www.onetwotrip.com/", "_hotels/api/suggestRequest");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _restClient.Dispose();
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [Description("Get hotels with limit")]
        public async Task GetHotelsWithLimit(int limit)
        {
            var response = await _restClient.GetHotels("Moscow", limit.ToString());
            var responseContent = await response.Content.ReadAsAsync<ResponseModel>();
            Assert.That(responseContent.error, Is.Null, "Check for errors");
            Assert.That(responseContent.result, Is.Not.Empty, "Check result not empty");
            Assert.That(responseContent.result.Count, Is.EqualTo(limit), "Check count results in responss");
        }

        [TestCase("Ufa")]
        [TestCase("Уфа")]
        [TestCase("Moscow")]
        [TestCase("Москва")]
        [TestCase("Мос")]
        [TestCase("Mos")]
        [Description("Get hotels with query")]
        public async Task GetHotelsByQuery(string query)
        {
            var response = await _restClient.GetHotels(query);
            var responseContent = await response.Content.ReadAsAsync<ResponseModel>();
            Assert.That(responseContent.error, Is.Null, "Check for errors");
            Assert.That(responseContent.result, Is.Not.Empty, "Check result not empty");
            foreach (var result in responseContent.result)
            {
                Assert.That(JsonConvert.SerializeObject(result).ToLower().Contains(query.ToLower()));
                switch (result.type)
                {
                    case "hotel":
                        Assert.That(result.name, Is.Not.Empty);
                        Assert.That(result.city, Is.Not.Empty);
                        Assert.That(result.country, Is.Not.Empty);
                        break;
                    case "geo":
                        Assert.That(result.name, Is.Not.Empty);
                        Assert.That(result.country, Is.Not.Empty);
                        break;
                    case "airport":
                        Assert.That(result.name, Is.Not.Empty);
                        Assert.That(result.country, Is.Not.Empty);
                        Assert.That(result.city, Is.Not.Empty);
                        break;
                    default:
                        throw new Exception("Unknown type of result");
                }
            }
        }
    }
}