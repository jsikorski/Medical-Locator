using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.LocationServices;

namespace MedicalLocator.Mobile.BingMaps
{
    public class BingMapHelper : IBingMapHelper
    {
        private readonly IBingMapHandler _bingMapHandler;

        public BingMapHelper(IBingMapHandler bingMapHandler)
        {
            _bingMapHandler = bingMapHandler;
        }

        public void ResetMap()
        {
            ClearPushpins();
        }

        public void SetPushpinsUsingGooglePlacesWcfResponse(
            Location centerLocation,
            GooglePlacesWcfResponse response)
        {
            SetCenterPushpin(_bingMapHandler, centerLocation);
            SetObjectsPushpins(_bingMapHandler, response);
            _bingMapHandler.UpdateBingMapView();
        }

        private void SetCenterPushpin(IBingMapHandler bingMapHandler, Location centerLocation)
        {
            var centerPushpin = new PushpinViewModel("Me", string.Empty, centerLocation.ToGeoCoordinate(), PushpinType.UserPushpin);
            bingMapHandler.BingMapPushpins.Add(centerPushpin);
        }

        private void SetObjectsPushpins(IBingMapHandler bingMapHandler, GooglePlacesWcfResponse response)
        {
            var pushpins = GetPushpinsViewModelsFromResponse(response).ToList();
            bingMapHandler.BingMapPushpins.AddRange(pushpins);
        }

        private IEnumerable<PushpinViewModel> GetPushpinsViewModelsFromResponse(GooglePlacesWcfResponse googlePlacesWcfResponse)
        {
            return googlePlacesWcfResponse.Results.Select(
                result => new PushpinViewModel(
                              result.Name,
                              result.Vicinity,
                              GetCoordinatesFromWcfResult(result),
                              GetPushpinTypeFromApiResult(result)));
        }

        private GeoCoordinate GetCoordinatesFromWcfResult(GooglePlacesWcfResult wcfResult)
        {
            return wcfResult.Location.ToGeoCoordinate();
        }

        private PushpinType GetPushpinTypeFromApiResult(GooglePlacesWcfResult wcfResult)
        {
            MedicalType medicalType = MedicalTypesConverter.FromGoogleService(wcfResult.Type);
            return PushpinType.FromMedicalType(medicalType);
        }

        private void ClearPushpins()
        {
            _bingMapHandler.BingMapPushpins.Clear();
        }
    }
}