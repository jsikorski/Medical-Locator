using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesApiResponse
    {
        [DataMember]
        public IEnumerable<ApiResult> Results { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}