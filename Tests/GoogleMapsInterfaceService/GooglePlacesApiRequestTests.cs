using System.Collections.Generic;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Model;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class GooglePlacesApiRequestTests
    {
        [Test]
        public void request_is_correctly_transformed_to_url()
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

            string actual = googlePlacesApiRequest.ToRequestUrl();
            Assert.IsTrue(actual.Contains("https://maps.googleapis.com/maps/api/place/search/json?"));
            Assert.IsTrue(actual.Contains("key="));
            Assert.IsTrue(actual.Contains("&location=50.0,25.0&radius=500&types=dentist&sensor=true"));
        }
    }
}