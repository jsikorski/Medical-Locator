using System.Collections.Generic;

namespace MedicalLocator.WebFront.Models
{
    public interface IEnumsValuesProvider
    {
        IEnumerable<MedicalType> GetAllMedicalTypes();
        IEnumerable<CenterType> GetAllCenterTypes();
    }
}
