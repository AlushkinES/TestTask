using System.Threading.Tasks;
using NUnit.Framework;
using RestHelper;

namespace Tests
{
    [TestFixture]
    [Timeout(10000)]
    [Category("Redirection")]
    public class RedirectionTest
    {
        private RestClient _restClient;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _restClient = new RestClient("https://onetwotrip.com/", redirection: false);
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _restClient.Dispose();
        }

        [Test]
        [Description("Redirection test from onetwotrip.com to www.onetwotrip.com")]
        public async Task RedirectTest()
        {
            var result = await _restClient.GetRequest();
            Assert.That((int)result.StatusCode, Is.EqualTo(301), "Check redirection status code");
            Assert.That(result.Headers.Location.ToString(), Is.EqualTo("https://www.onetwotrip.com/"), "Check redirection location");
        }
    }
}