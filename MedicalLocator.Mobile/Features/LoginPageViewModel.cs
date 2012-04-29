using System;
using Autofac;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Features
{
    public class LoginPageViewModel
    {
        private readonly IContainer _container;
        private readonly Func<LoginData, Login> _loginFactory;

        public LoginPageViewModel(IContainer container, Func<LoginData, Login> loginFactory)
        {
            _container = container;
            _loginFactory = loginFactory;
        }

        public bool Login(bool anonymously, string login, string password)
        {
            if (anonymously)
                return LoginAnonymously();

            return LoginByNameAndPass(login, password);
        }

        private bool LoginAnonymously()
        {
            var loginData = new LoginData { IsAnonymous = true };
            var command = _loginFactory(loginData);
            CommandInvoker.Invoke(command);
            return true;
        }

        private bool LoginByNameAndPass(string login, string password)
        {
            var loginData = new LoginData {IsAnonymous = false, Login = login, Password = password};
            var command = _loginFactory(loginData);
            CommandInvoker.Invoke(command);
            return true;
        }

        public bool RegisterNewUser(string name, string password)
        {
            var command = _container.Resolve<Register>();
            command.SetNameAndPass(name, password);
            CommandInvoker.Invoke(command);
            return true;
        }
    }
}