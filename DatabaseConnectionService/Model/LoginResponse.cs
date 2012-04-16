using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public bool IsAnonymous { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastUsedAddress { get; set; }

        [DataMember]
        public int LastUsedRange { get; set; }

        //[DataMember]
        //public string LastUsedCoordinates { get; set; }

        // centre type, gps settings?, list of medical objects types.
    }
}
