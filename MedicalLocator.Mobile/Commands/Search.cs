using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class Search : LocationServicesCommand
    {
        private readonly ILocationProvider _locationProvider;
        private readonly CurrentContext _currentContext;
        private readonly IBusyScope _busyScope;

        public Search(
            ILocationProvider locationProvider,
            CurrentContext currentContext,
            IBusyScope busyScope)
        {
            _locationProvider = locationProvider;
            _currentContext = currentContext;
            _busyScope = busyScope;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                Location centerLocation = _locationProvider.GetCenterLocation();
                bool isGpsUsed = _currentContext.AreLocationServicesAllowed;
                IEnumerable<MedicalType> searchedObjects = _currentContext.SearchedObjects;

                var request = new GooglePlacesApiRequest
                {
                    Location = centerLocation,
                    IsGpsUsed = isGpsUsed,
                    MedicalTypes = new ObservableCollection<MedicalType>(searchedObjects),
                    Radius = _currentContext.Range
                };
                var client = new GoogleMapsInterfaceServiceClient();
                GooglePlacesApiResponse response = client.SendGooglePlacesApiRequest(request);
            }
        }
    }
}