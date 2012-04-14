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
        public string Login { get; set; }

        public LoginPageViewModel(IContainer container, CurrentContext currentContext)
        {
            _container = container;
            _currentContext = currentContext;

            IsAnonymouslyLogin = false;
            Login = "";
        }

        public void OpenMainPage()
        {
            // todo: add error handling (eg. empty string in login field).
            if (IsAnonymouslyLogin)
                _currentContext.LoggedInUser = "Anonymously";
            else
                _currentContext.LoggedInUser = Login;

            var command = _container.Resolve<ShowMainPage>();
            CommandInvoker.Execute(command);
        }
    }
}