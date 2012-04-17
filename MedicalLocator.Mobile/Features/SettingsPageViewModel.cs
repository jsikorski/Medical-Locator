using System.Collections.Generic;
using Caliburn.Micro;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using System.Linq;

namespace MedicalLocator.Mobile.Features
{
    public class SettingsPageViewModel : Screen
    {
        private readonly CurrentContext _currentContext;

        public string LoggedInUserName
        {
            get { return (_currentContext.LoggedInUserModel == null) ? "anonymous" : _currentContext.LoggedInUserModel.Login; }
        }

        public bool AreLocationServicesAllowed
        {
            get { return _currentContext.AreLocationServicesAllowed; }
            set { _currentContext.AreLocationServicesAllowed = value; }
        }

        public SettingsPageViewModel(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }
    }
}