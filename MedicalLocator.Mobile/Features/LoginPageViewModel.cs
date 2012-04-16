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
        private readonly CurrentContext _currentContext;
        private readonly Func<LoginData, Login> _loginFactory;

        public bool IsAnonymouslyLogin { get; set; }

        public LoginPageViewModel(IContainer container, CurrentContext currentContext, Func<LoginData, Login> loginFactory)
        {
            _container = container;
            _currentContext = currentContext;
            _loginFactory = loginFactory;
            IsAnonymouslyLogin = false;
        }

        public bool RegisterNewUser(string name, string password)
        {
            var command = _container.Resolve<Register>();
            command.SetNameAndPass(name, password);
            CommandInvoker.Invoke(command);
            return true;
        }

        public bool LoginByNameAndPass(string login, string password)
        {
            var loginData = new LoginData {Login = login, Password = password, Container = _container};
            var command = _loginFactory(loginData);
            CommandInvoker.Invoke(command);
            return true;
        }

        public bool LoginAnonymously()
        {
            var loginData = new LoginData { Login = null, Password = null, Container = _container };
            var command = _loginFactory(loginData);
            CommandInvoker.Invoke(command);
            return true;
        }
    }
}