using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesWcfResult
    {
        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public MedicalType Type { get; set; } 
    }
}