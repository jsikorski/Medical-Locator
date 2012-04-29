using Autofac;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.Logging;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public class Login : 
        ICommand,
        IHasErrorHandler<InvalidLoginException>
    {
        private readonly ILoggingManager _loggingManager;
        private readonly LoginData _loginData;
        private readonly IContainer _container;

        public Login(LoginData loginData, ILoggingManager loggingManager, IContainer container)
        {
            _loginData = loginData;
            _loggingManager = loggingManager;
            _container = container;
        }

        public void Execute()
        {
            _loggingManager.TryLogin(_loginData);

            // Nie wiem jak to zrobić by z tego wątku w inny sposób przejść na stronę główną, więc zostawiam poniższe.
            var command = _container.Resolve<ShowMainPage>();
            CommandInvoker.Execute(command);
        }

        public void HandleError(InvalidLoginException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
