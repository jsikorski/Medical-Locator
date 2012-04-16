using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseConnectionService.Model;
using Raven.Client;
using Raven.Client.Document;

namespace DatabaseConnectionService
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        public LoginResponse Login(string login, string password)
        {
            var loginResponse = new LoginResponse();
            return loginResponse;
        }

        public RegisterStatus Register(string login, string password)
        {
            var status = new RegisterStatus();
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                // todo: validate login and password

                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var hasLogin = session.Query<MedicalLocatorUser>().Any(u => u.Login == login);
                    if (hasLogin)
                    {
                        status.IsSuccessful = false;
                        return status;
                    }

                    var lastSearch = new MedicalLocatorUserLastSearch { Address = "", Dentist = true, Hospital = true };
                    var user = new MedicalLocatorUser { Login = login, Password = password, LastSearch = lastSearch };
                    session.Store(user);
                    session.SaveChanges();
                }
            }

            status.IsSuccessful = true;
            return status;
        }

        // without pass?
        public bool SaveUserSettings(string login, MedicalLocatorUserLastSearch lastSearch)
        {
            return true;
        }
    }
}
