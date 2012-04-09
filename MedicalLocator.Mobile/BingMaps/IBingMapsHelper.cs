using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.BingMaps
{
    public interface IBingMapsHelper
    {
        void SetObjectsUsingGooglePlacesWcfResponse(IBingMapHandler bingMapHandler,
                                                    Location centerLocation,
                                                    GooglePlacesWcfResponse response);
    }
}