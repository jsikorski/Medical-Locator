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

            _busyScope.IsBusy = true;
        }

        public void Dispose()
        {
            _busyScope.IsBusy = false;
        }
    }
}