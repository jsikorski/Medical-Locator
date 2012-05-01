using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.DatabaseServices;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public class Login : 
        ICommand,
        IHasErrorHandler<InvalidLoginException>
    {
        private readonly IDatabaseManager _databaseManager;
        private readonly LoginData _loginData;
        private readonly INavigationService _navigationService;
        private readonly IBusyScope _loginPageViewModel;

        public Login(
            LoginData loginData, 
            IDatabaseManager databaseManager, 
            INavigationService navigationService,
            LoginPageViewModel loginPageViewModel)
        {
            _loginData = loginData;
            _databaseManager = databaseManager;
            _navigationService = navigationService;
            _loginPageViewModel = loginPageViewModel;
        }

        public void Execute()
        {
            using (new BusyArea(_loginPageViewModel))
            {
                _databaseManager.TryLogin(_loginData);
                Caliburn.Micro.Execute.OnUIThread(() => 
                    _navigationService.UriFor<MainPageViewModel>().WithParam(vm => vm.BackNavSkipOne, true).Navigate());            
            }
        }

        public void HandleError(InvalidLoginException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
