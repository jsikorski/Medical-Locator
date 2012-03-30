﻿using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class StartGps : ICommand
    {
        private readonly IGpsManager _gpsManager;
        private readonly IBusyScope _busyScope;

        public StartGps(IGpsManager gpsManager, MainPageViewModel busyScope)
        {
            _gpsManager = gpsManager;
            _busyScope = busyScope;
        }

        public void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                _gpsManager.StartGps();                
            }
        }
    }
}