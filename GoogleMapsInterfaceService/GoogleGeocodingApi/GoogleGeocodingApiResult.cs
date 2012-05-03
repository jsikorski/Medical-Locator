using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsInterfaceService.GooglePlacesApi;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class GoogleGeocodingApiResult
    {
        [DataMember]
        public Geometry Geometry { get; set; }
    }
}