using System.Runtime.Serialization;
using GoogleMapsInterfaceService.Model;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesWcfResult
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Vicinity { get; set; }
        [DataMember]
        public Location Location { get; set; }
        [DataMember]
        public MedicalTypeGoogleService Type { get; set; } 
    }
}