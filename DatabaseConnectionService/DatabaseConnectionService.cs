using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common.Enums;
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

            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => (u.Login == login && u.Password == password)).ToList();
                    if (userList.Count == 0)
                    {
                        loginResponse.IsValid = false;
                        return loginResponse;
                    }

                    var user = userList[0];
                    loginResponse.IsValid = true;
                    loginResponse.IsAnonymous = false;
                    loginResponse.UserData = user;
                }
            }

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
                    var hasLogin = session.Query<MedicalLocatorUserData>().Any(u => u.Login == login);
                    if (hasLogin)
                    {
                        status.IsSuccessful = false;
                        return status;
                    }

                    var lastSearch = new MedicalLocatorUserLastSearch { CenterType = CenterType.MyLocation, Range = 2500 };
                    var user = new MedicalLocatorUserData { Login = login, Password = password, LastSearch = lastSearch };
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
