using System.Collections.Generic;

namespace MedicalLocator.WebFront.Models
{
    public class MedicalTypesProvider : IMedicalTypesProvider
    {
        public IEnumerable<MedicalType> GetAllMedicalTypes()
        {
            return new[]
                       {
                           MedicalType.Dentist, 
                           MedicalType.Doctor, 
                           MedicalType.Health, 
                           MedicalType.Hospital,
                           MedicalType.Physiotherapist, 
                           MedicalType.Pharmacy
                       };
        }
    }
}