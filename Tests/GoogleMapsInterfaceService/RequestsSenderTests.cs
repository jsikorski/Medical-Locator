using System.Collections.Generic;
using GoogleMapsInterfaceService;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Key;
using GoogleMapsInterfaceService.Requests;
using NSubstitute;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class RequestsSenderTests
    {
        [Test]
        public void GooglePlacesApiRequestSendTest()
        {
            string key = KeysProvider.GooglePlacesApiKey;
            const int radius = 500;
            const bool isGpsUsed = true;
            var medialTypes = new List<MedicalType> {MedicalType.Dentist};
            var location = Substitute.For<Location>(50.0, 25.0);
            location.ToUrlFormat().Returns("50.0,25.0");

            var googlePlacesApiRequest = new GooglePlacesApiRequest(key, location, radius, isGpsUsed, medialTypes);
            var requestsSender = new RequestsSender();
            string response = requestsSender.SendRequest(googlePlacesApiRequest);

            Assert.IsNotNullOrEmpty(response);
        }
    }
}