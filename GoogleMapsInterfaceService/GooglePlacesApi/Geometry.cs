using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class Geometry
    {
        [DataMember]
        public Location Location { get; set; }
    }
}