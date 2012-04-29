using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class RegisterResponse
    {
        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        // Factory methods
        public static RegisterResponse CreateInvalid(string message)
        {
            return new RegisterResponse { IsSuccessful = false, ErrorMessage = message };
        }

        public static RegisterResponse CreateValid()
        {
            return new RegisterResponse { IsSuccessful = true };
        }
    }
}
