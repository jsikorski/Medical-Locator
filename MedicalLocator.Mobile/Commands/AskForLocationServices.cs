using System.Windows;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public class AskForLocationServices : ICommand
    {
        private readonly CurrentContext _currentContext;

        public AskForLocationServices(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }

        public void Execute()
        {
            MessageBoxResult questionResult = MessageBoxService.ShowQuestion("Medical Locator needs to use " +
                                                                             "location services for some functions. " +
                                                                             "Without them it will be still possible " +
                                                                             "to use application but some of the " +
                                                                             "features might be not available. "+
                                                                             "Please click ok if you agree to use location services.");
            _currentContext.AreLocationServicesAllowed = questionResult == MessageBoxResult.OK;
        }
    }
}