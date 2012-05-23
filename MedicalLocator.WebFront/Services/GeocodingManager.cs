using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;

namespace MedicalLocator.WebFront.Services
{
    public class GeocodingManager : IGeocodingManager
    {
        private readonly IGoogleMapsInterfaceService _googleMapsInterfaceService;

        public GeocodingManager(IGoogleMapsInterfaceService googleMapsInterfaceService)
        {
            _googleMapsInterfaceService = googleMapsInterfaceService;
        }

        public Location ExecuteGeocoding(string address)
        {
            GoogleGeocodingWcfResponse response = GetResponseFromGoogleGeocodingApi(address);
            return new Location {Lat = response.Results[0].Location.Lat, Lng = response.Results[0].Location.Lng};
        }

        private GoogleGeocodingWcfResponse GetResponseFromGoogleGeocodingApi(string address)
        {
            var request = new GoogleGeocodingApiRequest {Address = address, IsGpsUsed = true};
            GoogleGeocodingWcfResponse response =
                _googleMapsInterfaceService.SendGoogleGeocodingApiRequest(request);

            if (response.Status == Status1.Zero_Results)
            {
                throw new NoGeocodingResultsException();
            }

            return response;
        }
    }
}