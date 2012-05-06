using System.Collections.Generic;

namespace MedicalLocator.WebFront.Models
{
    public interface IMedicalTypesProvider
    {
        IEnumerable<MedicalType> GetAllMedicalTypes();
    }
}