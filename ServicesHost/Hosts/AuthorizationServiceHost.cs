using System.ServiceModel;
using ServicesHost.Utils;

namespace ServicesHost.Hosts
{
    public class AuthorizationServiceHost : IServiceHost
    {
        ServiceHost _serviceHost;

        private bool _isServiceRunning;
        public bool IsServiceRunning
        {
            get { return _isServiceRunning; }
        }

        public void StartService()
        {
            ConsoleController.Write("Starting authorization service...");

            _serviceHost = new ServiceHost(typeof(AuthorizationService.AuthorizationService));
            _serviceHost.Open();
            _isServiceRunning = true;
            
            ConsoleController.Write("Authorization service started.");
            ConsoleController.ShowServiceHostEndpoints(_serviceHost);
        }

        public void StopService()
        {
            ConsoleController.Write("Stoping authorizaion service...");

            _serviceHost.Close();
            _isServiceRunning = false;

            ConsoleController.Write("Authorization service stopped.");
        }
    }
}