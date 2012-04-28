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

        public IEnumerable<MedicalType> LastSearchedObjects { get; set; }
        public CenterType LastCenterType { get; set; }
        public int LastRange { get; set; }
        public string LastAddress { get; set; }
        public double LastLongitude { get; set; }
        public double LastLatitude { get; set; }

        public string CurrentUserLogin { get; set; }
        public string CurrentUserPassword { get; set; }

      //  public void SetLoggedInUserModel(MedicalLocatorUserData userModel)
     //   {
      //      if (userModel.LastSearch.SearchedObjects == null)
     //           userModel.LastSearch.SearchedObjects =
     //               new ObservableCollection<MedicalType>(_enumsValuesProvider.GetAllMedicalTypes());
//
    //        LoggedInUserModel = userModel;
    //    }
    
        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
        }
    }
}