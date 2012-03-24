using System.Collections.Generic;
using System.IO;
using GoogleMapsInterfaceService;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Key;
using GoogleMapsInterfaceService.Requests;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Tests.GoogleMapsInterfaceService
{
    public class ServiceTests
    {
        [Test]
        public void SendGooglePlacesRequestTest()
        {
            string requestFormat = File.ReadAllText(@"Resources\googlePlacesApiTestRequestFormat.txt");
            string requestUrl = string.Format(requestFormat, KeysProvider.GooglePlacesApiKey);
            string requestResponse = File.ReadAllText(@"Resources\googlePlacesApiTestJsonResponse.txt");

            var location = Substitute.For<Location>();
            location.Lat = 52.406368;
            location.Lng = 16.925158;
            location.ToUrlFormat().Returns("52.406368,16.925158");

            var request = Substitute.For<GooglePlacesApiRequest>();
            request.Key = KeysProvider.GooglePlacesApiKey;
            request.IsGpsUsed = true;
            request.Location = location;
            request.MedicalTypes = new List<MedicalType> { MedicalType.Doctor };
            request.Radius = 1;
            request.ToRequestUrl().Returns(requestUrl);

            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(requestResponse);

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            GooglePlacesApiResponse response = service.SendGooglePlacesApiRequest(request);

            Assert.IsNotNull(response.Results);
            Assert.IsNotEmpty(response.Results);
            Assert.AreEqual("OK", response.Status);

            Location responseLocation = response.Results.First().Geometry.Location;
            Assert.AreNotEqual(0.0, responseLocation.Lat);
            Assert.AreNotEqual(0.0, responseLocation.Lng);
        }
    }
}