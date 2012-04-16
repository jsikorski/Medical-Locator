using System.Collections.Generic;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Model
{
    public class EnumsValuesProvider : IEnumsValuesProvider
    {
        public IEnumerable<MedicalType> GetAllMedicalTypes()
        {
            return new[] { MedicalType.Dentist, MedicalType.Doctor };
        }

        public IEnumerable<CenterType> GetAllCenterTypes()
        {
            return new[] { CenterType.MyLocation, CenterType.Address, CenterType.Coordinates };
        }
    }
}