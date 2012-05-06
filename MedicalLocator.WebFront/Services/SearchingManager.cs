using System.Collections.Generic;
using System.Linq;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Models;

namespace MedicalLocator.WebFront.Services
{
    public class SearchingManager : ISearchingManager
    {
        private readonly GoogleMapsInterfaceServiceClient _googleMapsInterfaceServiceClient;

        public SearchingManager(GoogleMapsInterfaceServiceClient googleMapsInterfaceServiceClient)
        {
            _googleMapsInterfaceServiceClient = googleMapsInterfaceServiceClient;
        }

        public GooglePlacesWcfResponse GetDataFromGooglePlacesApi(Location centerPosition, 
            IEnumerable<MedicalType> searchedMedicalTypes, int searchingRange)
        {
            var medicalTypesForGoogleService = MedicalTypesConverter.ToGoogleService(searchedMedicalTypes).ToArray();
            var googlePlacesApiRequest = new GooglePlacesApiRequest
            {
                IsGpsUsed = false,
                Location = centerPosition,
                Radius = searchingRange,
                MedicalTypes = medicalTypesForGoogleService
            };

            GooglePlacesWcfResponse response = _googleMapsInterfaceServiceClient.SendGooglePlacesApiRequest(googlePlacesApiRequest);

            if (response.Status == Status.Zero_Results)
            {
                throw new NoSearchResultsException();
            }

            return response;
        }
    }
}