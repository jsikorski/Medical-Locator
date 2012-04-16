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
        RegisterStatus Register(string login, string password);

        [OperationContract]
        bool SaveUserSettings(string login, MedicalLocatorUserLastSearch lastSearch);
    }
}
