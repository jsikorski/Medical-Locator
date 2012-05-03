using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class GoogleGeocodingWcfResult
    {
        [DataMember]
        public Location Location { get; set; }
    }
}