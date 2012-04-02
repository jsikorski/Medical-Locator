using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class OpenSettingsPage : ICommand
    {
        private readonly INavigationService _navigationService;

        public OpenSettingsPage(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Execute()
        {
            _navigationService.UriFor<SettingsPageViewModel>().Navigate();
        }
    }
}