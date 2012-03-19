using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthenticationService
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        bool TryLogin(string login, string password);

        [OperationContract]
        void Logout();
    }
}
