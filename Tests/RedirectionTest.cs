using System.Threading.Tasks;
using NUnit.Framework;
using RestHelper;

namespace Tests
{
    [TestFixture]
    [Category("Category")]
    [Timeout(30000)]
    public class RedirectionTest
    {
        private RestClient _restClient;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _restClient = new RestClient("https://onetwotrip.com/");
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _restClient.Dispose();
        }

        [Test]
        public async Task RedirectTest()
        {
            var result = await _restClient.GetRequest();
        }
    }
}