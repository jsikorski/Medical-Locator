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

        public MedicalLocatorUserData LoggedInUserModel { get; private set; }

        public void SetLoggedInUserModel(MedicalLocatorUserData userModel)
        {
            if (userModel.LastSearch.SearchedObjects == null)
                userModel.LastSearch.SearchedObjects =
                    new ObservableCollection<MedicalType>(_enumsValuesProvider.GetAllMedicalTypes());

            LoggedInUserModel = userModel;
        }

        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
        }
    }
}