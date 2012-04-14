using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DatabaseConnectionService
{
    [ServiceContract]
    public interface IDatabaseConnectionService
    {
        [OperationContract]
        bool TryLogin(string login, string password);

        [OperationContract]
        void Logout();
    }
}
