using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using System.Linq;

namespace MedicalLocator.Mobile.Commands
{
    public class Search : SearchingCommand
    {
        private readonly ILocationProvider _locationProvider;
        private readonly ISearchingManager _searchingManager;
        private readonly CurrentContext _currentContext;
        private readonly INavigationService _navigationService;
        private readonly IBusyScope _mainPageViewModel;

        public Search(
            ILocationProvider locationProvider,
            ISearchingManager searchingManager,
            CurrentContext currentContext,
            INavigationService navigationService,
            MainPageViewModel mainPageViewModel)
        {
            _locationProvider = locationProvider;
            _searchingManager = searchingManager;
            _currentContext = currentContext;
            _navigationService = navigationService;
            _mainPageViewModel = mainPageViewModel;
        }

        public override void Execute()
        {
            GoToMapPage();

            using (new BusyArea(_mainPageViewModel))
            {
                Location centerLocation = _locationProvider.GetCenterLocation();
                IEnumerable<MedicalType> selectedMedicalTypes = _currentContext.GetSelectedMedicalTypes();
                _searchingManager.ExecuteSearching(centerLocation, _currentContext.LastRange, selectedMedicalTypes);
            }
        }

        private void GoToMapPage()
        {
            Caliburn.Micro.Execute.OnUIThread(() => _navigationService.UriFor<MainPageViewModel>().Navigate());
        }
    }
}