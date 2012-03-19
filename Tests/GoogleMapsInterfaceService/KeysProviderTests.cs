using GoogleMapsInterfaceService;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Key;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class KeysProviderTests
    {
        [Test]
        public void GooglePlacesApiKeyTest()
        {
            Assert.IsNotNull(KeysProvider.GooglePlacesApiKey);
        }
    }
}