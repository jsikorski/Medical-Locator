using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Navigation;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Commands
{
    public class LoginData
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAnonymous { get; set; }
    }

    public class Login : ICommand
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly IContainer _container;
        private readonly LoginData _loginData;

        public Login(CurrentContext currentContext, IEnumsValuesProvider enumsValuesProvider, IContainer container, LoginData loginData)
        {
            _container = container;
            _enumsValuesProvider = enumsValuesProvider;
            _currentContext = currentContext;
            _container = container;
            _loginData = loginData;
        }

        private bool TryLoginAnonymously()
        {
            _currentContext.CurrentUserLogin = "anonymous";
            _currentContext.CurrentUserPassword = null;
            _currentContext.LastAddress = "";
            _currentContext.LastCenterType = CenterType.MyLocation;
            _currentContext.LastLatitude = 0;
            _currentContext.LastLongitude = 0;
            _currentContext.LastRange = 2500;
            _currentContext.LastSearchedObjects = _enumsValuesProvider.GetAllMedicalTypes();
            return true;
        }

        private bool TryLoginByNameAndPassword()
        {
            var client = new DatabaseConnectionServiceClient();
            var loginResponse = client.Login(_loginData.Login, _loginData.Password);
            if (!loginResponse.IsValid)
            {
                // ?
                return false;
            }

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
            return true;
        }

        private bool TryLogin()
        {
            if (_loginData.IsAnonymous)
                return TryLoginAnonymously();
            
            return TryLoginByNameAndPassword();
        }

        public void Execute()
        {
            if (!TryLogin())
            {
                // ?
                return;
            }

            var command = _container.Resolve<ShowMainPage>();
            CommandInvoker.Execute(command);
        }
    }
}
