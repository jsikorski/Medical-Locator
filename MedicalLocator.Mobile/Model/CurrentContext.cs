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
        public int Range { get; set; }
        public CenterType CenterType { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public IEnumerable<MedicalType> SelectedSearchedObjects { get; set; }

        public CurrentContext(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
            Range = 2500;
            CenterType = CenterType.MyLocation;
            Address = string.Empty;
            
            SelectedSearchedObjects = _enumsValuesProvider.GetAllMedicalTypes();
        }
    }
}