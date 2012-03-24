using System.Collections.Generic;
using GoogleMapsInterfaceService.GooglePlacesApi;
using NSubstitute;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class GooglePlacesApiRequestTests
    {
        [Test]
        public void ToRequestUrlTest()
        {
            const string key = "testKey";
            const int radius = 500;
            const bool isGpsUsed = true;
            var medialTypes = new List<MedicalType> {MedicalType.Dentist};
            var location = Substitute.For<Location>();
            location.Lat = 50.0;
            location.Lng = 25.0;
            location.ToUrlFormat().Returns("50.0,25.0");

            var googlePlacesApiRequest = new GooglePlacesApiRequest
                                             {
                                                 Key = key,
                                                 IsGpsUsed = isGpsUsed,
                                                 Location = location,
                                                 MedicalTypes = medialTypes,
                                                 Radius = radius
                                             };

            const string expected = "https://maps.googleapis.com/maps/api/place/search/json?" +
                                    "key=testKey&location=50.0,25.0&radius=500&types=dentist&sensor=true";
            string actual = googlePlacesApiRequest.ToRequestUrl();
            Assert.AreEqual(expected, actual);
        }
    }
}