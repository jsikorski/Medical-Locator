using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Commands
{
    public class Login : ICommand
    {
        private readonly CurrentContext _currentContext;
        private string _login;
        private string _pass;
        public Login(CurrentContext currentContext)
        {
            _currentContext = currentContext;
            _login = null;
            _pass = null;
        }

        public void SetLoginAndPass(string login, string pass)
        {
            _login = login;
            _pass = pass;
        }

        public void Execute()
        {
            var loginResponse = new LoginResponse();
            if (_login == null)
            {
                loginResponse.IsAnonymous = true;
                loginResponse.IsValid = true;
            }
            else
            {
                var client = new DatabaseConnectionServiceClient();
                loginResponse = client.Login(_login, _pass);   
            }
            
            // todo:
            if (loginResponse.IsValid)
            {
                if (loginResponse.IsAnonymous)
                    _currentContext.LoggedInUser = "Anonymous";
                else
                    _currentContext.LoggedInUser = loginResponse.Name;
            }
            else
            {
                _currentContext.LoggedInUser = "Error user";
            }
        }
    }
}
