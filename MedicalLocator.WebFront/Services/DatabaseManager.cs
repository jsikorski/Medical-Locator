﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using MedicalLocator.WebFront.DatabaseConnectionReference;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        public void TrySaveSettings()
        {
            // Sprawdzenie czy jesteśmy zalogowani i mamy poprawny AuthenticationTicket zawierający userId.
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return;

            HttpCookie formsCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (formsCookie == null)
                return;

            FormsAuthenticationTicket auth = FormsAuthentication.Decrypt(formsCookie.Value);
            var userId = new Guid(auth.UserData);

            // Pobranie z aktualnej sesji danych ostatniego wyszukiwania (można byłoby też to przekazywać przez parametr tej metody).
            var sessionLastSearch = SessionManager.LastSearchData;
            var searchedObjects = MedicalTypesConverter.ToDatabaseService(sessionLastSearch.SearchedMedicalTypes);
            var toDatabaseLastSearch = new MedicalLocatorUserLastSearch
            {
                Address = sessionLastSearch.SearchedAddress,
                CenterType = CenterTypeConverter.ToDatabaseService(sessionLastSearch.CenterType),
                Latitude = sessionLastSearch.SearchedLatitude ?? 0,
                Longitude = sessionLastSearch.SearchedLongitude ?? 0,
                Range = sessionLastSearch.SearchingRange,
                SearchedObjects = new ObservableCollection<MedicalTypeDatabaseService>(searchedObjects).ToArray()
            };

            // Połączenie z bazą danych i zapisanie ostatnich parametrów wyszukiwania.
            var client = new DatabaseConnectionServiceClient();
            var saveSettingsResponse = client.SaveSettingsEx(userId, toDatabaseLastSearch);
            if (!saveSettingsResponse.IsSuccessful)
                throw new InvalidSaveSettingsException(saveSettingsResponse.ErrorMessage);
        }

        public void TryLogin(LoginData loginData)
        {
            // Próba połączenia z bazą danych i zalogowania
            var client = new DatabaseConnectionServiceClient();
            var loginResponse = client.Login(loginData.Login, loginData.Password);
            if (!loginResponse.IsSuccessful)
                throw new InvalidLoginException(loginResponse.ErrorMessage);

            // Udało się, pobieram dane, które udało się wyciągnąć z bazy danych.
            var user = loginResponse.UserData;
            var databaseSearchData = user.LastSearch;
            var userData = user.UserId.ToString();

            // Tworzę AuthenticationTicket mający przechowywać ID użytkownika (w userData) potrzebne do zapisywania ustawień.
            var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddDays(30), loginData.RememberMe, userData);
            var hashedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Add(cookie);

            // Aktualizuję ustawienia aktualnej sesji.
            var sessionSearchData = new SearchData
            {
                SearchedAddress = databaseSearchData.Address,
                SearchedLatitude = databaseSearchData.Latitude,
                SearchedLongitude = databaseSearchData.Longitude,
                SearchingRange = databaseSearchData.Range,
                CenterType = (CenterType) databaseSearchData.CenterType,
                SearchedMedicalTypes = MedicalTypesConverter.FromDatabaseService(databaseSearchData.SearchedObjects)
            };
            SessionManager.IsAnonymous = false;
            SessionManager.CurrentUserLogin = user.Login;
            SessionManager.LastSearchData = sessionSearchData;
        }

        public void TryRegister(RegisterData registerData)
        {
            var client = new DatabaseConnectionServiceClient();
            var regiserResponse = client.Register(registerData.LicenceAgree, registerData.Login, registerData.Password, registerData.PasswordRetype);
            if (!regiserResponse.IsSuccessful)
                throw new InvalidRegisterException(regiserResponse.ErrorMessage);
        }

        public void TryLogout()
        {
            // Wylogowję się, niszczę sesję i dodatkowo usuwam cookiesa (niesetety sam się nie usuwa).
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
        }
    }
}