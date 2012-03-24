using GoogleMapsInterfaceService.GooglePlacesApi;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class LocationTests
    {
        [Test]
        public void ToUrlStringAccurateValuesTest()
        {
            var location = new Location { Lat = 25.0, Lng = 50.0 };

            const string expected = "25,50";
            string actiual = location.ToUrlFormat();
            Assert.AreEqual(expected, actiual);
        }

        [Test]
        public void ToUrlStringNotAccurateValuesTest()
        {
            var location = new Location { Lat = 25.55, Lng = 50.44 };

            const string expected = "25.55,50.44";
            string actiual = location.ToUrlFormat();
            Assert.AreEqual(expected, actiual);
        }
    }
}