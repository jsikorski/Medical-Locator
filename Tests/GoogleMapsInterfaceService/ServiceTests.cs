using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Common.Keys;
using GoogleMapsInterfaceService;
using GoogleMapsInterfaceService.Faults;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Requests;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Tests.GoogleMapsInterfaceService
{
    public class ServiceTests
    {
        [Test]
        public void user_can_receive_correct_response()
        {
            string requestUrl = GetCorrectRequestUrl();
            string requestResponse = GetCorrectRequestResponse();

            var location = Substitutes.GetLocationSubstitute();
            var request = Substitutes.GetGooglePlacesApiRequestSubstitute(location, requestUrl, KeysProvider.GooglePlacesApiKey);
            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(requestResponse);

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            GooglePlacesApiResponse response = service.SendGooglePlacesApiRequest(request);

            Assert.IsNotNull(response.Results);
            Assert.IsNotEmpty(response.Results);
            Assert.AreEqual(Status.Ok, response.Status);

            Location responseLocation = response.Results.First().Geometry.Location;
            Assert.AreNotEqual(0.0, responseLocation.Lat);
            Assert.AreNotEqual(0.0, responseLocation.Lng);
        }

        [Test]
        public void connection_fault_is_send_when_cannot_connect()
        {
            const string invalidUrl = "localhost:8080/InvalidUrl";

            var location = Substitutes.GetLocationSubstitute();
            var request = Substitutes.GetGooglePlacesApiRequestSubstitute(location, invalidUrl, KeysProvider.GooglePlacesApiKey);
            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(x => { throw new Exception(); });

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            Assert.Throws<FaultException<ConnectionFault>>(() => service.SendGooglePlacesApiRequest(request));
        }

        [Test]
        public void invalid_response_fault_is_send_when_reveived_invalid_response()
        {
            string requestUrl = GetCorrectRequestUrl();
            const string requestResponse = "i.n.v.a.l.i.d...r.e.s.p.o.n.s.e.";

            var location = Substitutes.GetLocationSubstitute();
            var request = Substitutes.GetGooglePlacesApiRequestSubstitute(location, requestUrl, KeysProvider.GooglePlacesApiKey);
            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(requestResponse);

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            Assert.Throws<FaultException<InvalidResponseFault>>(() => service.SendGooglePlacesApiRequest(request));
        }

        [Test]
        public void request_denied_fault_is_send_when_google_places_api_key_is_invalid()
        {
            string requestUrl = GetCorrectRequestUrl();
            string requestResponse = GetRequestDeniedRequestResponse();

            var location = Substitutes.GetLocationSubstitute();
            var request = Substitutes.GetGooglePlacesApiRequestSubstitute(location, requestUrl, "invalid key");
            var requestSender = Substitute.For<IRequestsSender>();
            requestSender.SendRequest(request).Returns(requestResponse);

            IGoogleMapsInterfaceService service
                = new global::GoogleMapsInterfaceService.GoogleMapsInterfaceService(requestSender);
            Assert.Throws<FaultException<RequestDeniedFault>>(() => service.SendGooglePlacesApiRequest(request));
        }

        private static string GetCorrectRequestUrl()
        {
            string requestFormat = File.ReadAllText(@"Resources\googlePlacesApiRequestFormat.txt");
            return string.Format(requestFormat, KeysProvider.GooglePlacesApiKey);
        }

        private static string GetCorrectRequestResponse()
        {
            return File.ReadAllText(@"Resources\googlePlacesApiJsonResponse.txt");
        }

        private static string GetRequestDeniedRequestResponse()
        {
            return File.ReadAllText(@"Resources\googlePlacesApiDeniedJsonResponse.txt");
        }
    }
}