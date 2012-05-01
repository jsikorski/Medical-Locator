using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.DatabaseServices;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public class Register :
        ICommand,
        IHasErrorHandler<InvalidRegisterException>
    {
        private readonly IDatabaseManager _databaseManager;
        private readonly RegisterData _registerData;
        private readonly IBusyScope _loginPageViewModel;

        public Register(
            RegisterData registerData, 
            IDatabaseManager databaseManager, 
            LoginPageViewModel loginPageViewModel)

        {
            _registerData = registerData;
            _databaseManager = databaseManager;
            _loginPageViewModel = loginPageViewModel;
        }

        public void Execute()
        {
            using (new BusyArea(_loginPageViewModel))
            {
                _databaseManager.TryRegister(_registerData);
            }

            MessageBoxService.ShowInformation("User " + _registerData.Login + " created successfully!");
        }

        public void HandleError(InvalidRegisterException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
