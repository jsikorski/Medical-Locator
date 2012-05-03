using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class GoogleGeocodingApiResponse
    {
        [DataMember]
        public IEnumerable<GoogleGeocodingApiResult> Results { get; set; }

        [DataMember]
        public Status Status { get; set; }
    }
}