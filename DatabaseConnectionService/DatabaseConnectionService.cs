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
            // Simple validation of login and password.
            if (login.Length < 3 || login.Length > 16)
                return LoginResponse.CreateInvalid("Incorrect length of username.");

            if (password.Length < 3 || password.Length > 16)
                return LoginResponse.CreateInvalid("Incorrect length of password.");

            if (login.ToLower().Trim() == "anonymous")
                return LoginResponse.CreateInvalid("You can not log in with username 'anonymous'.");

            // Retrieve data from database.
            using (IDocumentStore documentStore = new DocumentStore { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => (u.Login == login && u.Password == password)).ToList();
                    if (userList.Count == 0)
                    {
                        return LoginResponse.CreateInvalid("Wrong login or password.");
                    }

                    return LoginResponse.CreateValid(userList[0]);
                }
            }
        }

        public RegisterResponse Register(bool licenceAgree, string login, string password, string passwordRetype)
        {
            // Simple validation.
            if (!licenceAgree)
                return RegisterResponse.CreateInvalid("You must accept the license agreement.");

            if (login.Length < 3 || login.Length > 16)
                return RegisterResponse.CreateInvalid("Incorrect length of username.");

            if (password != passwordRetype)
                return RegisterResponse.CreateInvalid("The passwords are not identical.");

            if (password.Length < 3 || password.Length > 16)
                return RegisterResponse.CreateInvalid("Incorrect length of password.");

            if (login.ToLower().Trim() == "anonymous")
                return RegisterResponse.CreateInvalid("You can not create an account with username 'anonymous'.");

            // Store data in database.
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var hasLogin = session.Query<MedicalLocatorUserData>().Any(u => u.Login == login);
                    if (hasLogin)
                        return RegisterResponse.CreateInvalid("There is a user with username '" + login + "'. Try a different login.");

                    session.Store(MedicalLocatorUserData.CreateDefaultUser(login, password));
                    session.SaveChanges();
                }
            }

            return RegisterResponse.CreateValid();
        }

        public bool SaveUserSettings(string login, string password, MedicalLocatorUserLastSearch lastSearch)
        {
            // todo
            return true;
        }
    }
}
