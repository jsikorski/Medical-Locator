using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.ServicesReferences;
using System.Linq;

namespace MedicalLocator.Mobile.Services
{
    public class GoogleMapsInterfaceServiceProxy : IGoogleMapsInterfaceServiceProxy
    {
        private readonly CurrentContext _currentContext;

        public GoogleMapsInterfaceServiceProxy(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }

        public GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(
            Location centerLocation, IEnumerable<MedicalType> searchedObjects, int range)
        {
            var client = new GoogleMapsInterfaceServiceClient();
            bool isGpsUsed = _currentContext.AreLocationServicesAllowed;
            var medicalTypes = new ObservableCollection<MedicalType>(searchedObjects);

            var request = new GooglePlacesApiRequest
            {
                IsGpsUsed = isGpsUsed,
                Location = centerLocation,
                MedicalTypes = medicalTypes,
                Radius = range
            };

            return client.SendGooglePlacesApiRequest(request);
        }
    }
}