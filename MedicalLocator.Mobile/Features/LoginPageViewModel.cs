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

        private void OpenMainPage()
        {
            var command = _container.Resolve<ShowMainPage>();
            CommandInvoker.Execute(command);
        }

        public bool RegisterNewUser(string name, string password)
        {
            // todo: insert to database
            return true;
        }

        public bool LoginByNameAndPass(string name, string password)
        {
            _currentContext.LoggedInUser = name;

            OpenMainPage();
            return true;
        }

        public bool LoginAnonymously()
        {
            _currentContext.LoggedInUser = "anonymously";

            OpenMainPage();
            return true;
        }
    }
}