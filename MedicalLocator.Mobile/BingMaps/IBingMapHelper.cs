using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.BingMaps
{
    public interface IBingMapHelper
    {
        void SetObjectsUsingGooglePlacesWcfResponse(Location centerLocation,
                                                    GooglePlacesWcfResponse response);
    }
}