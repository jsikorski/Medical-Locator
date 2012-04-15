using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class ShowMainPage : UICommand
    {
        private readonly INavigationService _navigationService;

        public ShowMainPage(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override void ExecuteOnUI()
        {
            _navigationService.UriFor<MainPageViewModel>().Navigate();
        }
    }
}