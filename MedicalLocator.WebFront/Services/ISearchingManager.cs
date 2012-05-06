using System.Collections.Generic;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Models;

namespace MedicalLocator.WebFront.Services
{
    public interface ISearchingManager
    {
        GooglePlacesWcfResponse GetDataFromGooglePlacesApi(Location centerPosition,
            IEnumerable<MedicalType> searchedMedicalTypes, int searchingRange);
    }
}