using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class GoogleGeocodingWcfResponse
    {
        [DataMember]
        public IEnumerable<GoogleGeocodingWcfResult> Results { get; set; }

        [DataMember]
        public Status Status { get; set; } 
    }
}