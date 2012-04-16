using System;
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
        public IContainer Container { get; set; }
    }

    public class Login : ICommand
    {
        private readonly CurrentContext _currentContext;
        private string _login;
        private string _pass;
        private IContainer _container;
        public Login(CurrentContext currentContext, LoginData loginData)
        {
            _currentContext = currentContext;
            _login = loginData.Login;
            _pass = loginData.Password;
            _container = loginData.Container;
        }

        public void SetLoginAndPass(string login, string pass, IContainer container)
        {
            _login = login;
            _pass = pass;
            _container = container;
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
            
            if (loginResponse.IsValid)
            {
                if (loginResponse.IsAnonymous)
                    _currentContext.LoggedInUser = null;
                else
                    _currentContext.LoggedInUser = loginResponse.User;

                var command = _container.Resolve<ShowMainPage>();
                CommandInvoker.Invoke(command);
            }
            else
            {
                // todo: login error message
            }
        }
    }
}
