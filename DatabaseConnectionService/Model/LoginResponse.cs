using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public MedicalLocatorUserData UserData { get; set; }

        // Factory methods
        public static LoginResponse CreateInvalid(string message)
        {
            return new LoginResponse { IsSuccessful = false, ErrorMessage = message };
        }

        public static LoginResponse CreateValid(MedicalLocatorUserData userData)
        {
            return new LoginResponse { IsSuccessful = true, UserData = userData };
        }
    }
}
