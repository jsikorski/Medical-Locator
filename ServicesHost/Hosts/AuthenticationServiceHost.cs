using System.ServiceModel;
using ServicesHost.Utils;

namespace ServicesHost.Hosts
{
    public class AuthenticationServiceHost : IServiceHost
    {
        ServiceHost _serviceHost;

        private bool _isServiceRunning;
        public bool IsServiceRunning
        {
            get { return _isServiceRunning; }
        }

        public void StartService()
        {
            ConsoleController.Write("Starting authentication service...");

            _serviceHost = new ServiceHost(typeof(AuthenticationService.AuthenticationService));
            _serviceHost.Open();
            _isServiceRunning = true;

            ConsoleController.Write("Authentication service started.");
            ConsoleController.ShowServiceHostEndpoints(_serviceHost);
        }

        public void StopService()
        {
            ConsoleController.Write("Stoping authentication service...");

            _serviceHost.Close();
            _isServiceRunning = false;

            ConsoleController.Write("Authentication service stopped.");
        }
    }
}