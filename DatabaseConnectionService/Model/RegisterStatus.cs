using System.Runtime.Serialization;

namespace DatabaseConnectionService.Model
{
    [DataContract]
    public class RegisterStatus
    {
        [DataMember]
        public bool IsSuccessful { get; set; }
    }
}
