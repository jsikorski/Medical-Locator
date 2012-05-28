using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using MedicalLocator.WebFront.DatabaseConnectionReference;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        public void TrySaveSettings()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return;

            HttpCookie formsCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (formsCookie == null)
                return;

            FormsAuthenticationTicket auth = FormsAuthentication.Decrypt(formsCookie.Value);
            var userId = new Guid(auth.UserData);

            var sessionLastSearch = SessionManager.LastSearchData;

            var searchedObjects = MedicalTypesConverter.ToDatabaseService(sessionLastSearch.SearchedMedicalTypes);
            var lastSearch = new MedicalLocatorUserLastSearch
            {
                Address = sessionLastSearch.SearchedAddress,
                CenterType = CenterTypeConverter.ToDatabaseService(sessionLastSearch.CenterType),
                Latitude = sessionLastSearch.SearchedLatitude ?? 0,
                Longitude = sessionLastSearch.SearchedLongitude ?? 0,
                Range = sessionLastSearch.SearchingRange,
                SearchedObjects = new ObservableCollection<MedicalTypeDatabaseService>(searchedObjects).ToArray()
            };

            var client = new DatabaseConnectionServiceClient();
            var saveSettingsResponse = client.SaveSettingsEx(userId, lastSearch);
            if (!saveSettingsResponse.IsSuccessful)
                throw new InvalidSaveSettingsException(saveSettingsResponse.ErrorMessage);
        }

        public void TryRegister(RegisterData registerData)
        {
            var client = new DatabaseConnectionServiceClient();
            var regiserResponse = client.Register(true, registerData.Login, registerData.Password, registerData.Password);
            if (!regiserResponse.IsSuccessful)
                throw new InvalidRegisterException(regiserResponse.ErrorMessage);
        }

        public void TryLogin(LoginData loginData)
        {
            var client = new DatabaseConnectionServiceClient();
            var loginResponse = client.Login(loginData.Login, loginData.Password);
            if (!loginResponse.IsSuccessful)
                throw new InvalidLoginException(loginResponse.ErrorMessage);

            var user = loginResponse.UserData;
            var databaseSearchData = user.LastSearch;

            string userData = user.UserId.ToString();

            var ticket = new FormsAuthenticationTicket(1, user.Login,
                DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                true, userData);

            string hashedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);

            SessionManager.IsAnonymous = false;
            SessionManager.CurrentUserLogin = user.Login;

            var sessionSearchData = new SearchData();
            sessionSearchData.SearchedAddress = databaseSearchData.Address;
            sessionSearchData.SearchedLatitude = databaseSearchData.Latitude;
            sessionSearchData.SearchedLongitude = databaseSearchData.Longitude;
            sessionSearchData.SearchingRange = databaseSearchData.Range;

            sessionSearchData.CenterType = (CenterType)databaseSearchData.CenterType;

            sessionSearchData.SearchedMedicalTypes =
                MedicalTypesConverter.FromDatabaseService(databaseSearchData.SearchedObjects);

            SessionManager.LastSearchData = sessionSearchData;
        }

        public void TryLogout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
        }
    }
}