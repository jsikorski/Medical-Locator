using System.Collections.Generic;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public interface IMedicalTypesProvider
    {
        IEnumerable<MedicalType> GetAllMedicalTypes();
    }
}