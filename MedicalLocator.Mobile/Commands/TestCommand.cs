using System.Threading;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class TestCommand : ICommand
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public TestCommand(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public void Execute()
        {
            using (new BusyArea(_mainPageViewModel))
            {
                Thread.Sleep(5000);
            }
        }
    }
}