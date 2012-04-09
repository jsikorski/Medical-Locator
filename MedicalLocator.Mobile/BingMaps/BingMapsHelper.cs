using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using Caliburn.Micro;
using MedicalLocator.Mobile.Messages;
using MedicalLocator.Mobile.ServicesReferences;
using Microsoft.Phone.Controls.Maps;
using MedicalLocator.Mobile.Services.LocationServices;

namespace MedicalLocator.Mobile.BingMaps
{
    public class BingMapsHelper : IBingMapsHelper
    {
        public void SetObjectsUsingGooglePlacesWcfResponse(
            IBingMapHandler bingMapHandler,
            Location centerLocation,
            GooglePlacesWcfResponse response)
        {
            bingMapHandler.BingMapPushpins.Clear();
            SetCenterPushpin(bingMapHandler, centerLocation);

            if (!response.Results.Any())
            {
                bingMapHandler.UpdateBingMapView();
                return;
            }
            
            SetObjectsPushpins(bingMapHandler, response);
            bingMapHandler.UpdateBingMapView();
        }

        private void SetCenterPushpin(IBingMapHandler bingMapHandler, Location centerLocation)
        {
            var centerPushpin = new PushpinViewModel(centerLocation.ToGeoCoordinate(), PushpinType.UserPushpin);
            bingMapHandler.BingMapPushpins.Add(centerPushpin);
        }

        private void SetObjectsPushpins(IBingMapHandler bingMapHandler, GooglePlacesWcfResponse response)
        {
            var pushpins = GetPushpinsViewModelsFromResponse(response);
            bingMapHandler.BingMapPushpins.AddRange(pushpins);
        }

        private IEnumerable<PushpinViewModel> GetPushpinsViewModelsFromResponse(GooglePlacesWcfResponse googlePlacesWcfResponse)
        {
            return googlePlacesWcfResponse.Results.Select(
                result => new PushpinViewModel(
                              GetCoordinatesFromWcfResult(result),
                              GetPushpinTypeFromApiResult(result)));
        }

        private GeoCoordinate GetCoordinatesFromWcfResult(GooglePlacesWcfResult wcfResult)
        {
            return wcfResult.Location.ToGeoCoordinate();
        }

        private PushpinType GetPushpinTypeFromApiResult(GooglePlacesWcfResult wcfResult)
        {
            MedicalType medicalType = wcfResult.Type;
            return PushpinType.FromMedicalType(medicalType);
        }
    }
}