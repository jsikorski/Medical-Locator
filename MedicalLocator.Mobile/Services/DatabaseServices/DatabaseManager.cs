using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using System.Linq;

namespace MedicalLocator.Mobile.Services.DatabaseServices
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;

        public DatabaseManager(CurrentContext currentContext, IEnumsValuesProvider enumsValuesProvider)
        {
            _currentContext = currentContext;
            _enumsValuesProvider = enumsValuesProvider;
        }

        public void TryRegister(RegisterData registerData)
        {
            var client = new DatabaseConnectionServiceClient();
            var regiserResponse = client.Register(registerData.LicenceAgree, registerData.Login, registerData.Password, registerData.PasswordRetype);
            if (!regiserResponse.IsSuccessful)
                throw new InvalidRegisterException(regiserResponse.ErrorMessage);
        }

        public void TrySaveSettings(SaveSettingsData saveSettingsData)
        {
            var searchedObjects = MedicalTypesConverter.ToDatabaseService(saveSettingsData.SearchedObjects);
            var lastSearch = new MedicalLocatorUserLastSearch
                                 {
                                     Address = saveSettingsData.Address,
                                     CenterType = CenterTypeConverter.ToDatabaseService(saveSettingsData.CenterType),
                                     Latitude = saveSettingsData.Latitude,
                                     Longitude = saveSettingsData.Longitude,
                                     Range = saveSettingsData.Range,
                                     SearchedObjects = new ObservableCollection<MedicalTypeDatabaseService>(searchedObjects)
                                 };
            var client = new DatabaseConnectionServiceClient();
            var saveSettingsResponse = client.SaveSettings(saveSettingsData.Login, saveSettingsData.Password, lastSearch);
            if (!saveSettingsResponse.IsSuccessful)
                throw new InvalidRegisterException(saveSettingsResponse.ErrorMessage);
        }

        public void TryLogin(LoginData loginData)
        {
            if (loginData.IsAnonymous)
            {
                TryLoginAnonymously();
            }
            else
            {
                TryLoginByNameAndPassword(loginData);
            }
        }

        private void TryLoginAnonymously()
        {
            _currentContext.IsAnonymousUser = true;
            _currentContext.CurrentUserLogin = "anonymous";
            _currentContext.CurrentUserPassword = null;
            _currentContext.LastAddress = string.Empty;
            _currentContext.LastCenterType = CenterType.MyLocation;
            _currentContext.LastLatitude = 0;
            _currentContext.LastLongitude = 0;
            _currentContext.LastRange = 2500;
            _currentContext.LastSearchedMedicalTypes =
                _enumsValuesProvider.GetAllMedicalTypes().Select(type => new MedicalTypeViewModel(type, true)).ToList();

            _currentContext.SavedLastSearchHash = _currentContext.GenerateLastSearchedHash();
        }

        private void TryLoginByNameAndPassword(LoginData loginData)
        {
            var client = new DatabaseConnectionServiceClient();
            var loginResponse = client.Login(loginData.Login, loginData.Password);
            if (!loginResponse.IsSuccessful)
                throw new InvalidLoginException(loginResponse.ErrorMessage);

            var user = loginResponse.UserData;
            var lastSearch = user.LastSearch;
            _currentContext.IsAnonymousUser = false;
            _currentContext.CurrentUserLogin = user.Login;
            _currentContext.CurrentUserPassword = user.Password;
            _currentContext.LastAddress = lastSearch.Address;
            _currentContext.LastCenterType = CenterTypeConverter.FromDatabaseService(lastSearch.CenterType);
            _currentContext.LastLatitude = lastSearch.Latitude;
            _currentContext.LastLongitude = lastSearch.Longitude;
            _currentContext.LastRange = lastSearch.Range;

            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            IEnumerable<MedicalType> lastMedicalTypes = MedicalTypesConverter.FromDatabaseService(lastSearch.SearchedObjects);
            _currentContext.LastSearchedMedicalTypes =
                allMedicalTypes.Select(type => new MedicalTypeViewModel(type, lastMedicalTypes.Contains(type))).ToList();

            _currentContext.SavedLastSearchHash = _currentContext.GenerateLastSearchedHash();
        }
    }
}