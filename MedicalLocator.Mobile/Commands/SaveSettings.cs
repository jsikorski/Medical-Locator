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
    public class SaveSettings :
        ICommand,
        IHasErrorHandler<InvalidSaveSettingsException>
    {
        private readonly IDatabaseManager _databaseManager;
        private readonly CurrentContext _currentContext;

        public SaveSettings(CurrentContext currentContext, IDatabaseManager databaseManager)
        {
            _currentContext = currentContext;
            _databaseManager = databaseManager;
        }

        public void Execute()
        {
            if (_currentContext.IsAnonymousUser || !_currentContext.AreSearchParametersChanged())
                return;

            var saveSettingsData = new SaveSettingsData
            {
                Login = _currentContext.CurrentUserLogin,
                Password = _currentContext.CurrentUserPassword,
                Address = _currentContext.LastAddress,
                CenterType = _currentContext.LastCenterType,
                Latitude = _currentContext.LastLatitude,
                Longitude = _currentContext.LastLongitude,
                Range = _currentContext.LastRange,
                SearchedObjects = _currentContext.GetSelectedMedicalTypes()
            };

            _databaseManager.TrySaveSettings(saveSettingsData);

            _currentContext.SavedLastSearchHash = _currentContext.GenerateLastSearchedHash();
            
            // MessageBoxService.ShowInformation("Settings for user " + saveSettingsData.Login + " saved successfully!");
        }

        public void HandleError(InvalidSaveSettingsException exception)
        {
            MessageBoxService.ShowError(exception.Error);
        }
    }
}
