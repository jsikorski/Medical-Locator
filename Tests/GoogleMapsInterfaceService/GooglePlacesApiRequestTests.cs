using System.Collections.Generic;
using System.ComponentModel;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Requests;
using NUnit.Framework;

namespace Tests.GoogleMapsInterfaceService
{
    public class GooglePlacesApiRequestTests
    {
        private IRequest _googlePlacesApiRequest;

        [TearDown]
        public void SetUp()
        {
            _googlePlacesApiRequest = null;
        }

        [Test]
        public void ToRequestStringCorrect()
        {
            _googlePlacesApiRequest = new GooglePlacesApiRequest(
                "testKey", new Location(50.0, 25.0), 500, true, 
                new List<MedicalType> { MedicalType.Dentist });

            const string expected = "https://maps.googleapis.com/maps/api/place/search/json?" +
                                    "key=testKey&location=50.0,25.0&radius=500&types=dentist&sensor=true";
            string actual = _googlePlacesApiRequest.ToRequestString();
            Assert.AreEqual(expected, actual);
        }


    }
}