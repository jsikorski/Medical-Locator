using GoogleMapsInterfaceService.Keys;
using NUnit.Framework;

namespace Tests.Common
{
    public class KeysProviderTests
    {
        [Test]
        public void google_places_api_key_seems_to_be_correct()
        {
            Assert.IsNotNullOrEmpty(KeysProvider.GooglePlacesApiKey);
        }
    }
}