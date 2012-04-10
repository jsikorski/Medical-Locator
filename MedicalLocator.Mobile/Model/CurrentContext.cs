using System.Collections.Generic;
using System.Device.Location;
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
        public int SearchingRange { get; set; }
        public CenterType SearchingCenterType { get; set; }
        public string SearchedAddress { get; set; }
        public double SearchedLongitude { get; set; }
        public double SearchedLatitude { get; set; }

        public IEnumerable<MedicalType> SelectedSearchedObjects { get; set; }

        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
            SearchingRange = 2500;
            SearchingCenterType = CenterType.MyLocation;
            SearchedAddress = string.Empty;
            
            SelectedSearchedObjects = _enumsValuesProvider.GetAllMedicalTypes();
        }
    }
}