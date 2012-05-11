using System.Collections.Generic;

namespace MedicalLocator.WebFront.Models
{
    public class EnumsValuesProvider : IEnumsValuesProvider
    {
        public IEnumerable<MedicalType> GetAllMedicalTypes()
        {
            return new[]
                       {
                           MedicalType.Dentist, 
                           MedicalType.Doctor, 
                           MedicalType.Health, 
                           MedicalType.Hospital, 
                           MedicalType.Pharmacy, 
                           MedicalType.Physiotherapist
                       };
        }

        public IEnumerable<CenterType> GetAllCenterTypes()
        {
            return new[] { CenterType.MyLocation, CenterType.Address, CenterType.Coordinates };
        }
    }
}