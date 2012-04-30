using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class SaveSettingsResponse
    {
        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        // Factory methods
        public static SaveSettingsResponse CreateInvalid(string message)
        {
            return new SaveSettingsResponse { IsSuccessful = false, ErrorMessage = message };
        }

        public static SaveSettingsResponse CreateValid()
        {
            return new SaveSettingsResponse { IsSuccessful = true };
        }
    }
}
