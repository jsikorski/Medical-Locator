using System;
using System.Threading;

namespace MedicalLocator.Mobile.Infrastructure
{
    public class BusyArea : IDisposable
    {
        private readonly IBusyScope _busyScope;

        public BusyArea(IBusyScope busyScope)
        {
            _busyScope = busyScope;

            TryHideApplicationBar();
            _busyScope.IsBusy = true;
        }

        public void Dispose()
        {
            _busyScope.IsBusy = false;
            TryShowApplicationBar();
        }

        private void TryHideApplicationBar()
        {
            if (_busyScope is IHasApplicationBar)
            {
                (_busyScope as IHasApplicationBar).ApplicationBar.IsVisible = false;
            }
        }

        private void TryShowApplicationBar()
        {
            if (_busyScope is IHasApplicationBar)
            {
                (_busyScope as IHasApplicationBar).ApplicationBar.IsVisible = true;
            }
        }
    }
}