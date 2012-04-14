using System.ServiceModel;
using ServicesHost.Utils;

namespace ServicesHost.Hosts
{
    public class DatabaseConnectionServiceHost : IServiceHost
    {
        ServiceHost _serviceHost;

        private bool _isServiceRunning;
        public bool IsServiceRunning
        {
            get { return _isServiceRunning; }
        }

        public void StartService()
        {
            ConsoleController.Write("Starting database connection service...");

            _serviceHost = new ServiceHost(typeof(DatabaseConnectionService.DatabaseConnectionService));
            _serviceHost.Open();
            _isServiceRunning = true;

            ConsoleController.Write("Database connection service started.");
            ConsoleController.ShowServiceHostEndpoints(_serviceHost);
        }

        public void StopService()
        {
            ConsoleController.Write("Stoping database connection service...");

            _serviceHost.Close();
            _isServiceRunning = false;

            ConsoleController.Write("Database connection service stopped.");
        }
    }
}