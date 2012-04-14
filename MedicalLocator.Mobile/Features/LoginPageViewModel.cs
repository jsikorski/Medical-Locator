using Autofac;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Features
{
    public class LoginPageViewModel
    {
        private readonly IContainer _container;
        
        public LoginPageViewModel(IContainer container)
        {
            _container = container;
        }

        public void OpenMainPage()
        {
            ExecuteCommand<ShowMainPage>();
        }

        private void ExecuteCommand<T>() where T : ICommand
        {
            var command = _container.Resolve<T>();
            CommandInvoker.Execute(command);
        }
    }
}