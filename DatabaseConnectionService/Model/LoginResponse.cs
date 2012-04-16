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
        public MedicalLocatorUser User { get; set; }
    }
}
