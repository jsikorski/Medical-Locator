using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DatabaseConnectionService
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        public bool TryLogin(string login, string password)
        {
            // todo
            if (login.ToLower().Trim() == "noirion")
                return false;

            return true;
        }

        public void Logout()
        {

        }
    }
}
