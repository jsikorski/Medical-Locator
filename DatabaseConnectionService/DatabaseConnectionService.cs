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
        private static LoginResponse ReturnInvalidLogin(string message)
        {
            return new LoginResponse { IsValid = false, ErrorMessage = message };
        }

        public LoginResponse Login(string login, string password)
        {
            // Simple validation of login and password.
            if (login.Length < 3 || login.Length > 16)
                return ReturnInvalidLogin("Wrong login length.");

            if (password.Length < 3 || password.Length > 16)
                return ReturnInvalidLogin("Wrong password length.");

            if (login.ToLower().Trim() == "anonymous")
                return ReturnInvalidLogin("Cannot log in with name 'anonymous'.");

            // Retrieve data from database.
            using (IDocumentStore documentStore = new DocumentStore { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => (u.Login == login && u.Password == password)).ToList();
                    if (userList.Count == 0)
                    {
                        return ReturnInvalidLogin("Wrong login or password.");
                    }

                    return new LoginResponse {IsValid = true, UserData = userList[0]};
                }
            }
        }

        public RegisterStatus Register(string login, string password)
        {
            var status = new RegisterStatus();
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var hasLogin = session.Query<MedicalLocatorUserData>().Any(u => u.Login == login);
                    if (hasLogin)
                    {
                        status.IsSuccessful = false;
                        return status;
                    }

                    var lastSearch = new MedicalLocatorUserLastSearch
                                         {
                                             SearchedObjects = DatabaseEnumsValuesProvider.GetAllMedicalTypes(),
                                             CenterType = CenterTypeDatabaseService.MyLocation, 
                                             Range = 2500,
                                             Address = "",
                                             Latitude = 0,
                                             Longitude = 0
                                         };

                    var user = new MedicalLocatorUserData
                                   {
                                       Login = login, 
                                       Password = password, 
                                       LastSearch = lastSearch
                                   };

                    session.Store(user);
                    session.SaveChanges();
                }
            }

            status.IsSuccessful = true;
            return status;
        }

        public bool SaveUserSettings(string login, string password, MedicalLocatorUserLastSearch lastSearch)
        {
            // todo
            return true;
        }
    }
}
