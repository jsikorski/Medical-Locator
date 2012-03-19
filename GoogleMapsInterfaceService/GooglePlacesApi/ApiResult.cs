using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class ApiResult
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Icon { get; set; }
        [DataMember]
        public Geometry Geometry { get; set; }
    }
}