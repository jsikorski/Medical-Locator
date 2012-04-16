using System.Collections.Generic;
using System.Device.Location;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Model
{
    [SingleInstance]
    public class CurrentContext
    {
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        public bool AreLocationServicesAllowed { get; set; }
        public MedicalLocatorUser LoggedInUser { get; set; }

        public IEnumerable<MedicalType> SelectedSearchedObjects { get; set; }

        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;

            LoggedInUser = null;
            
            SelectedSearchedObjects = _enumsValuesProvider.GetAllMedicalTypes();
        }
    }
}