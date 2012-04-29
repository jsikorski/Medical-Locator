﻿using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services.Logging
{
    public class LoggingManager : ILoggingManager
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;

        public LoggingManager(CurrentContext currentContext, IEnumsValuesProvider enumsValuesProvider)
        {
            _currentContext = currentContext;
            _enumsValuesProvider = enumsValuesProvider;
        }

        public void TryLogin(LoginData loginData)
        {
            if (loginData.IsAnonymous)
            {
                TryLoginAnonymously(loginData);
            }
            else
            {
                TryLoginByNameAndPassword(loginData);
            }
        }

        private void TryLoginAnonymously(LoginData loginData)
        {
            _currentContext.CurrentUserLogin = "anonymous";
            _currentContext.CurrentUserPassword = null;
            _currentContext.LastAddress = "";
            _currentContext.LastCenterType = CenterType.MyLocation;
            _currentContext.LastLatitude = 0;
            _currentContext.LastLongitude = 0;
            _currentContext.LastRange = 2500;
            _currentContext.LastSearchedObjects = _enumsValuesProvider.GetAllMedicalTypes();
        }

        private void TryLoginByNameAndPassword(LoginData loginData)
        {
            var client = new DatabaseConnectionServiceClient();
            var loginResponse = client.Login(loginData.Login, loginData.Password);
            if (!loginResponse.IsValid)
                throw new InvalidLoginException(loginResponse.ErrorMessage);

            var user = loginResponse.UserData;
            var lastSearch = user.LastSearch;
            _currentContext.CurrentUserLogin = user.Login;
            _currentContext.CurrentUserPassword = user.Password;
            _currentContext.LastAddress = lastSearch.Address;
            _currentContext.LastCenterType = CenterTypeConverter.FromDatabaseService(lastSearch.CenterType);
            _currentContext.LastLatitude = lastSearch.Latitude;
            _currentContext.LastLongitude = lastSearch.Longitude;
            _currentContext.LastRange = lastSearch.Range;
            _currentContext.LastSearchedObjects = MedicalTypeConverter.FromDatabaseService(lastSearch.SearchedObjects);
        }
    }
}