﻿using System.Collections.Generic;
using GoogleMapsInterfaceService.GoogleGeocodingApi;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Model;
using GoogleMapsInterfaceService.Requests;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class RequestsSenderTests
    {
        [Test]
        public void correct_request_gives_response_from_google_places_api()
        {
            var medialTypes = new List<MedicalTypeGoogleService> { MedicalTypeGoogleService.Dentist };
            var location = Substitutes.GetLocationSubstitute();

            var googlePlacesApiRequest = new GooglePlacesApiRequest
                                             {
                                                 IsGpsUsed = true,
                                                 Location = location,
                                                 MedicalTypes = medialTypes,
                                                 Radius = 500
                                             };
            var requestsSender = new RequestsSender();
            string response = requestsSender.SendRequest(googlePlacesApiRequest);

            Assert.IsNotNullOrEmpty(response);
        }

        [Test]
        public void correct_request_gives_response_from_google_geocoding_api()
        {
            var address = "Poznań, Półwiejska 20";

            var googleGeocodingApiRequest = new GoogleGeocodingApiRequest
            {
                IsGpsUsed = true,
                Address = address
            };

            var requestsSender = new RequestsSender();
            string response = requestsSender.SendRequest(googleGeocodingApiRequest);

            Assert.IsNotNullOrEmpty(response);
        }
    }
}