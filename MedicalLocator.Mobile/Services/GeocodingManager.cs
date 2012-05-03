using System.Collections.Generic;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services
{
    public class GeocodingManager : IGeocodingManager
    {
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;

        public GeocodingManager(IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy)
        {
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
        }

        public Location ExecuteGeocoding(string address)
        {
            GoogleGeocodingWcfResponse response = GetResponseFromGoogleGeocodingApi(address);
            return new Location {Lat = response.Results[0].Location.Lat, Lng = response.Results[0].Location.Lng};
        }

        private GoogleGeocodingWcfResponse GetResponseFromGoogleGeocodingApi(string address)
        {
            GoogleGeocodingWcfResponse response =
                _googleMapsInterfaceServiceProxy.GetResponseFromGoogleGeocodingApi(address);

            if (response.Status == Status1.Zero_Results)
            {
                throw new NoGeocodingResultsException();
            }

            return response;
        }
    }
}