using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        public bool TryLogin(string login, string password)
        {
            // TODO: Correct login to database
            return true;
        }

        public void Logout()
        {

        }
    }
}
