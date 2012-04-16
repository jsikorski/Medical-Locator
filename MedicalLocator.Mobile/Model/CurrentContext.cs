using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services;

namespace MedicalLocator.Mobile.Model
{
    [SingleInstance]
    public class CurrentContext
    {
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        public bool AreLocationServicesAllowed { get; set; }

        public MedicalLocatorUserData LoggedInUser { get; private set; }

        public void SetLoggedInUser(MedicalLocatorUserData user)
        {
            if (user.LastSearch.SearchedObjects == null)
                user.LastSearch.SearchedObjects =
                    new ObservableCollection<MedicalType>(_enumsValuesProvider.GetAllMedicalTypes());

            LoggedInUser = user;
        }

        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
        }
    }
}