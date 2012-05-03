using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class Geometry
    {
        [DataMember]
        public Location Location { get; set; }
    }
}