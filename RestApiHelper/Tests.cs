using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RestApiHelper.Models;
using TestTask;

namespace RestApiHelper
{
    [TestFixture]
    [Category("Category")]
    [Timeout(30000)]
    public class Tests
    {
        private RestClient RestClient;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var restClient = new RestClient();
        }
        
        [Test]
        [NUnit.Framework.Description("Get categories without additional query")]
        public async Task GetCategories()
        {
            var response = await RestClient.GetItem("UFA");
            var results = await response.Content.ReadAsAsync<ResponseModel>();
        }
    }
}