using System;
using Autofac;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.DatabaseServices;

namespace MedicalLocator.Mobile.Features
{
    public class LoginPageViewModel
    {
        private readonly Func<LoginData, Login> _loginFactory;
        private readonly Func<RegisterData, Register> _registerFactory;

        public LoginPageViewModel(Func<LoginData, Login> loginFactory, Func<RegisterData, Register> registerFactory)
        {
            _loginFactory = loginFactory;
            _registerFactory = registerFactory;
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
            var loginData = new LoginData { IsAnonymous = false, Login = login, Password = password };
            var command = _loginFactory(loginData);
            CommandInvoker.Invoke(command);
            return true;
        }

        public bool RegisterNewUser(bool licenceAgree, string login, string password, string passwordRetype)
        {
            var registerData = new RegisterData { LicenceAgree = licenceAgree, Login = login, Password = password, PasswordRetype = passwordRetype };
            var command = _registerFactory(registerData);
            CommandInvoker.Invoke(command);
            return true;
        }
    }
}