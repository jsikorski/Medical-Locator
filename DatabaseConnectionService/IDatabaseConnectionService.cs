using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseConnectionService.Model;

namespace DatabaseConnectionService
{
    [ServiceContract]
    public interface IDatabaseConnectionService
    {
        [OperationContract]
        LoginResponse Login(string login, string password);

        [OperationContract]
        RegisterResponse Register(bool licenceAgree, string login, string password, string passwordRetype);

        [OperationContract]
        SaveSettingsResponse SaveSettings(string login, string password, MedicalLocatorUserLastSearch lastSearch);
    }
}
