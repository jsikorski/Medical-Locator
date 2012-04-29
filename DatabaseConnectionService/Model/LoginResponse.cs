using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public MedicalLocatorUserData UserData { get; set; }
    }
}
