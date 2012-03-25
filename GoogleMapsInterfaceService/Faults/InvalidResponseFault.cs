using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.Faults
{
    [DataContract]
    public class InvalidResponseFault : FaultBase
    {
        [DataMember]
        public string ResponseText { get; set; } 
    }
}