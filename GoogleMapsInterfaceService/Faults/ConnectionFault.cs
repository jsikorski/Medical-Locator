using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.Faults
{
    [DataContract]
    public class ConnectionFault : FaultBase
    {
        [DataMember]
        public string RequestedAddress { get; set; }
        [DataMember]        
        public string Operation { get; set; }
    }
}