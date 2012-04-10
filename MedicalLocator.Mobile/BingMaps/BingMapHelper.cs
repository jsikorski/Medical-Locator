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
    public class BingMapHelper : IBingMapHelper
    {
        private readonly IBingMapHandler _bingMapHandler;

        public BingMapHelper(IBingMapHandler bingMapHandler)
        {
            _bingMapHandler = bingMapHandler;
        }

        public void SetObjectsUsingGooglePlacesWcfResponse(
            Location centerLocation,
            GooglePlacesWcfResponse response)
        {
            _bingMapHandler.BingMapPushpins.Clear();
            SetCenterPushpin(_bingMapHandler, centerLocation);

            if (!response.Results.Any())
            {
                _bingMapHandler.UpdateBingMapView();
                return;
            }

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
            var pushpins = GetPushpinsViewModelsFromResponse(response);
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
            MedicalType medicalType = wcfResult.Type;
            return PushpinType.FromMedicalType(medicalType);
        }
    }
}