using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesApiResult
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Icon { get; set; }
        [DataMember]
        public Geometry Geometry { get; set; }
        [DataMember]
        public IEnumerable<string> Types { get; set; }
    }
}