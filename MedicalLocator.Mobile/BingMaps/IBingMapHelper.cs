using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.BingMaps
{
    public interface IBingMapHelper
    {
        void ResetMap();
        void SetPushpinsUsingGooglePlacesWcfResponse(Location centerLocation,
                                                     GooglePlacesWcfResponse response);
    }
}