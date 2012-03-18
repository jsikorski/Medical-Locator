using System.ServiceModel;
using ServicesHost.Utils;

namespace ServicesHost.Hosts
{
    public class GoogleMapsInterfaceServiceHost : IServiceHost
    {
        private ServiceHost _serviceHost;

        private bool _isServiceRunning;
        public bool IsServiceRunning
        {
            get { return _isServiceRunning; }
        }

        public void StartService()
        {
            ConsoleController.Write("Starting Google Maps interface service...");

            _serviceHost = new ServiceHost(typeof(GoogleMapsInterfaceService.GoogleMapsInterfaceService));
            _serviceHost.Open();
            _isServiceRunning = true;

            ConsoleController.Write("Google maps interface service started.");
            ConsoleController.ShowServiceHostEndpoints(_serviceHost);
        }

        public void StopService()
        {
            ConsoleController.Write("Stoping Google Maps interface service...");

            _serviceHost.Close();
            _isServiceRunning = false;

            ConsoleController.Write("Google Maps interface service stopped.");
        }
    }
}