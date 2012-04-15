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

        public bool IsAnonymouslyLogin { get; set; }

        public LoginPageViewModel(IContainer container, CurrentContext currentContext)
        {
            _container = container;
            _currentContext = currentContext;
            IsAnonymouslyLogin = false;
        }

        public bool RegisterNewUser(string name, string password)
        {
            return true;
        }

        public bool LoginByNameAndPass(string name, string password)
        {
            var command = _container.Resolve<Login>();
            command.LoginByNameAndPass(name, password);
            CommandInvoker.Invoke(command);

            // dwa commandy kolo siebie nie wygladaja dobrze, jutro to poprawie.
            var command2 = _container.Resolve<ShowMainPage>();
            CommandInvoker.Invoke(command2);
            return true;
        }

        public bool LoginAnonymously()
        {
            var command = _container.Resolve<Login>();
            command.LoginAnonymously();
            CommandInvoker.Invoke(command);

            var command2 = _container.Resolve<ShowMainPage>();
            CommandInvoker.Invoke(command2);
            return true;
        }
    }
}