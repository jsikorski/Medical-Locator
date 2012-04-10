using System.Collections.Generic;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public interface ISearchingManager
    {
        void ExecuteSearching(Location centerLocation, int range, IEnumerable<MedicalType> searchedTypes);
    }
}