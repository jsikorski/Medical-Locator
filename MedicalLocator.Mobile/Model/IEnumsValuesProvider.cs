using System.Collections.Generic;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Model
{
    public interface IEnumsValuesProvider
    {
        IEnumerable<MedicalType> GetAllMedicalTypes();
        IEnumerable<CenterType> GetAllCenterTypes();
    }
}