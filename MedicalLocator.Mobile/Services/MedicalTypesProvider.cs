using System.Collections.Generic;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public class MedicalTypesProvider : IMedicalTypesProvider
    {
        public IEnumerable<MedicalType> GetAllMedicalTypes()
        {
            return new[] { MedicalType.Dentist, MedicalType.Doctor };
        }
    }
}