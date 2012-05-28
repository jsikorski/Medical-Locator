using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using DatabaseConnectionService.Model;
using DevOne.Security.Cryptography.BCrypt;
using Raven.Client;
using Raven.Client.Document;

namespace DatabaseConnectionService
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private const string PassAcceptedSpecialChars = "!@#$%^&*-_=+";
        static private readonly Regex LoginRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
        static private readonly Regex PasswordRegex = new Regex("^[a-zA-Z][a-zA-Z0-9" + Regex.Escape(PassAcceptedSpecialChars) + "]*$");

        public LoginResponse Login(string login, string password)
        {
            // Simple validation of login and password.
            if (login.Length < 3 || login.Length > 16)
                return LoginResponse.CreateInvalid("Incorrect length of username.");

            if (password.Length < 4 || password.Length > 31)
                return LoginResponse.CreateInvalid("Incorrect length of password.");

            if (login.ToLower().Trim() == "anonymous")
                return LoginResponse.CreateInvalid("You can not log in with username 'anonymous'.");

            if (!LoginRegex.IsMatch(login))
                return LoginResponse.CreateInvalid("Invalid characters in username.");

            if (!PasswordRegex.IsMatch(password))
                return LoginResponse.CreateInvalid("Invalid characters in password.");

            // Retrieve data from database.
            using (IDocumentStore documentStore = new DocumentStore { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => u.Login == login).ToList();

                    if (userList.Count == 0 || !BCryptHelper.CheckPassword(password, userList[0].Password))
                        return LoginResponse.CreateInvalid("Incorrect login or password.");

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

            if (password.Length < 4 || password.Length > 31)
                return RegisterResponse.CreateInvalid("Incorrect length of password.");

            if (login.ToLower().Trim() == "anonymous")
                return RegisterResponse.CreateInvalid("You can not create an account with username 'anonymous'.");

            if (!LoginRegex.IsMatch(login))
                return RegisterResponse.CreateInvalid("Invalid characters in username.");

            if (!PasswordRegex.IsMatch(password))
                return RegisterResponse.CreateInvalid("Invalid characters in password.");

            var salt = BCryptHelper.GenerateSalt();
            var hashedPassword = BCryptHelper.HashPassword(password, salt);

            // Store data in database.
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var hasLogin = session.Query<MedicalLocatorUserData>().Any(u => u.Login == login);
                    if (hasLogin)
                        return RegisterResponse.CreateInvalid("There is a user with username '" + login + "'. Try a different login.");

                    session.Store(MedicalLocatorUserData.CreateDefaultUser(login, hashedPassword));
                    session.SaveChanges();
                }
            }

            return RegisterResponse.CreateValid();
        }

        public SaveSettingsResponse SaveSettingsEx(Guid userId, MedicalLocatorUserLastSearch lastSearch)
        {
            // Store data in database.
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => (u.UserId == userId)).ToList();

                    if (userList.Count != 1)
                        return SaveSettingsResponse.CreateInvalid("Error while saving settings: Incorrect user ID.");

                    var user = userList[0];
                    user.LastSearch = lastSearch;
                    session.SaveChanges();
                    session.Store(user);
                    return SaveSettingsResponse.CreateValid();
                }
            }
        }

        // ! Zachowane wyłącznie dla zgodności z wersją na WP7, zmodyfikować ją tak by używała tej powyższej metody.
        public SaveSettingsResponse SaveSettings(string login, string password, MedicalLocatorUserLastSearch lastSearch)
        {
            if (login.Length < 3 || login.Length > 16)
                return SaveSettingsResponse.CreateInvalid("Error while saving settings: Incorrect length of username.");

            if (login.ToLower().Trim() == "anonymous")
                return SaveSettingsResponse.CreateInvalid("Error while saving settings: can not save settings with username 'anonymous'.");

            if (!LoginRegex.IsMatch(login))
                return SaveSettingsResponse.CreateInvalid("Error while saving settings: Invalid characters in username.");

            // Store data in database.
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    var userList = session.Query<MedicalLocatorUserData>().Where(u => (u.Login == login && u.Password == password)).ToList();
                    
                    if (userList.Count == 0)
                        return SaveSettingsResponse.CreateInvalid("Error while saving settings: Incorrect pass or login for '" + login + "'.");

                    var user = userList[0];
                    user.LastSearch = lastSearch;
                    session.SaveChanges();
                    session.Store(user);

                    return SaveSettingsResponse.CreateValid();
                }
            }
        }
    }
}
