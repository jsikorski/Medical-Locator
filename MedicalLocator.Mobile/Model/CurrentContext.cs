using System.Collections.Generic;
using System.Device.Location;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Model
{
    [SingleInstance]
    public class CurrentContext
    {
        public bool AreLocationServicesAllowed { get; set; }
        public int Range { get; set; }
        public CenterType CenterType { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public IEnumerable<MedicalType> SearchedObjects { get; set; }

        public CurrentContext()
        {
            Range = 2500;
            CenterType = CenterType.MyLocation;

            SearchedObjects = new List<MedicalType>();
        }
    }
}