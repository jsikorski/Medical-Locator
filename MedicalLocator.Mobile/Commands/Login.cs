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
    }

    public class Login : ICommand
    {
        private readonly CurrentContext _currentContext;
        private readonly IContainer _container;
        private readonly string _login;
        private readonly string _pass;

        public Login(CurrentContext currentContext, IContainer container, LoginData loginData)
        {
            _currentContext = currentContext;
            _container = container;
            _login = loginData.Login;
            _pass = loginData.Password;
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
                CommandInvoker.Execute(command);
            }
            else
            {
                // todo: login error message
            }
        }
    }
}
