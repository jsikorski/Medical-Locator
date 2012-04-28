using System.Collections.Generic;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services
{
    public interface ISearchingManager
    {
        void ExecuteSearching(Location centerLocation, int range, IEnumerable<MedicalType> searchedTypes);
    }
}