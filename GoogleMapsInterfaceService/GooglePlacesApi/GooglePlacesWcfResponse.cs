using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesWcfResponse
    {
        [DataMember]
        public IEnumerable<GooglePlacesWcfResult> Results { get; set; }

        [DataMember]
        public Status Status { get; set; } 
    }
}