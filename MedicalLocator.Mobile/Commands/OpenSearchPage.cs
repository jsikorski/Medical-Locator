using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class OpenSearchPage : ICommand
    {
        private readonly INavigationService _navigationService;

        public OpenSearchPage(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Execute()
        {
            _navigationService.UriFor<SearchPageViewModel>().Navigate();
        }
    }
}