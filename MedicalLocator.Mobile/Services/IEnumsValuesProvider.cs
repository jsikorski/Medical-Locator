using System.Collections.Generic;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public interface IEnumsValuesProvider
    {
        IEnumerable<MedicalType> GetAllMedicalTypes();
        IEnumerable<CenterType> GetAllCenterTypes();
    }
}