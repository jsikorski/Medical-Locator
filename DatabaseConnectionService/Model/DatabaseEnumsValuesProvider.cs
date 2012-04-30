using System.Collections.Generic;

namespace DatabaseConnectionService.Model
{
    public class DatabaseEnumsValuesProvider
    {
        static public IEnumerable<MedicalTypeDatabaseService> GetAllMedicalTypes()
        {
            return new[]
                       {
                           MedicalTypeDatabaseService.Dentist, 
                           MedicalTypeDatabaseService.Doctor, 
                           MedicalTypeDatabaseService.Health, 
                           MedicalTypeDatabaseService.Hospital, 
                           MedicalTypeDatabaseService.Pharmacy, 
                           MedicalTypeDatabaseService.Physiotherapist
                       };
        }

        static public IEnumerable<CenterTypeDatabaseService> GetAllCenterTypes()
        {
            return new[] { CenterTypeDatabaseService.MyLocation, CenterTypeDatabaseService.Address, CenterTypeDatabaseService.Coordinates };
        }
    }
}