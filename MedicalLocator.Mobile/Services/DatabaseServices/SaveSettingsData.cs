using System.Collections.Generic;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services.DatabaseServices
{
    public class SaveSettingsData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<MedicalType> SearchedObjects { get; set; }
        public CenterType CenterType { get; set; }
        public int Range { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}