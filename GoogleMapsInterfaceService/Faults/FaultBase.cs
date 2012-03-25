using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.Faults
{
    [DataContract]
    public class FaultBase
    {
        [DataMember]
        public string Message { get; set; }
    }
}