using BackOfficeManagerModels.Core;
using static System.Net.WebRequestMethods;

namespace BackOfficeManager.ModelTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetServerPropertiesTestAsync()
        {
            var service = new ServerPropertiesService();
            var adress = "https://petrov-training-demo.iiko.it/resto";
            var properties = await service.GetServerProperties(adress);
            Assert.That("STARTED_SUCCESSFULLY", Is.EqualTo(properties.ServerState.ToString()));
            //Assert.Pass();
        }
    }
}