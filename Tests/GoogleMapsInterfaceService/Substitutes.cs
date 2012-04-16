using System.Collections.Generic;
using Common.Enums;
using GoogleMapsInterfaceService.GooglePlacesApi;
using NSubstitute;

namespace Tests.GoogleMapsInterfaceService
{
    public static class Substitutes
    {
         public static Location GetLocationSubstitute()
         {
             var location = Substitute.For<Location>();
             location.Lat = 50.0;
             location.Lng = 25.0;
             location.ToUrlFormat().Returns("50.0,25.0");
             return location;
         }

        public static GooglePlacesApiRequest GetGooglePlacesApiRequestSubstitute(Location location, string url, string key)
         {
             var requestSubstitute = Substitute.For<GooglePlacesApiRequest>();
             requestSubstitute.IsGpsUsed = true;
             requestSubstitute.Location = location;
             requestSubstitute.MedicalTypes = new List<MedicalType> { MedicalType.Doctor };
             requestSubstitute.Radius = 1;
             requestSubstitute.ToRequestUrl().Returns(url);
             return requestSubstitute;
         }
    }
}