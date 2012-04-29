using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
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
        private readonly INavigationService _navigationService;

        public Login(LoginData loginData, ILoggingManager loggingManager, INavigationService navigationService)
        {
            _loginData = loginData;
            _loggingManager = loggingManager;
            _navigationService = navigationService;
        }

        public void Execute()
        {
            _loggingManager.TryLogin(_loginData);
            Caliburn.Micro.Execute.OnUIThread(() => _navigationService.UriFor<MainPageViewModel>().Navigate());            
        }

        public void HandleError(InvalidLoginException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
