using System.Collections.Generic;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public interface IGoogleMapsInterfaceServiceProxy
    {
        GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(
            Location centerLocation, IEnumerable<MedicalType> searchedObjects, int range);
    
    }
}