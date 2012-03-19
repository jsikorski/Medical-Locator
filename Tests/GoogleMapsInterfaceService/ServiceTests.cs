using System.Collections.Generic;
using System.IO;
using GoogleMapsInterfaceService;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Key;
using GoogleMapsInterfaceService.Requests;
using NSubstitute;
using NUnit.Framework;

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

            var location = Substitute.For<Location>(52.406368, 16.925158);
            location.ToUrlFormat().Returns("52.406368,16.925158");
            const int radius = 1;
            const bool isGpsUsed = true;
            var medialTypes = new List<MedicalType> { MedicalType.Doctor };

            var request = Substitute.For<GooglePlacesApiRequest>(KeysProvider.GooglePlacesApiKey,
                                                                 location, radius,
                                                                 isGpsUsed, medialTypes);
            request.ToRequestUrl().Returns(requestUrl);

            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(requestResponse);

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            GooglePlacesApiResponse response = service.SendGooglePlacesApiRequest(request);

            Assert.IsNotNull(response.Results);
            Assert.IsNotEmpty(response.Results);
            Assert.AreEqual("OK", response.Status);
        }
    }
}