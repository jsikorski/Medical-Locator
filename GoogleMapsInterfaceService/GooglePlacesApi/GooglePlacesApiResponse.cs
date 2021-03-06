using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesApiResponse
    {
        [DataMember]
        public IEnumerable<GooglePlacesApiResult> Results { get; set; }

        [DataMember]
        public Status Status { get; set; }
    }
}