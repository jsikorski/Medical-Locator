using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.Logging;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public class Register :
        ICommand,
        IHasErrorHandler<InvalidRegisterException>
    {
        private readonly ILoggingManager _loggingManager;
        private readonly RegisterData _registerData;

        public Register(RegisterData registerData, ILoggingManager loggingManager)
        {
            _registerData = registerData;
            _loggingManager = loggingManager;
        }

        public void Execute()
        {
            _loggingManager.TryRegister(_registerData);
            MessageBoxService.ShowInformation("User " + _registerData.Login + " created successfully!");
        }

        public void HandleError(InvalidRegisterException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
