using System.Collections.Generic;

namespace DatabaseConnectionService.Model
{
    public class DatabaseEnumsValuesProvider
    {
        static public IEnumerable<MedicalTypeDatabaseService> GetAllMedicalTypes()
        {
            return new[] { MedicalTypeDatabaseService.Dentist, MedicalTypeDatabaseService.Doctor };
        }

        static public IEnumerable<CenterTypeDatabaseService> GetAllCenterTypes()
        {
            return new[] { CenterTypeDatabaseService.MyLocation, CenterTypeDatabaseService.Address, CenterTypeDatabaseService.Coordinates };
        }
    }
}