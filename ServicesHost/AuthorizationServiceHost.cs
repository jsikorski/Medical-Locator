using System;
using System.ServiceModel;

namespace ServicesHost
{
    public class AuthorizationServiceHost : IServiceHost
    {
        ServiceHost _serviceHost;    

        public void StartService()
        {
            ConsoleController.Write("Starting authorization service...");

            _serviceHost = new ServiceHost(typeof(AuthorizationService.AuthorizationService));
            try
            {
                _serviceHost.Open();
            }
            catch (Exception)
            {
                ConsoleController.Write("Cannot start authorization service.");
                return;
            }

            ConsoleController.Write("Authorization service started.");
        }

        public void StopService()
        {
            ConsoleController.Write("Stoping authorizaion service...");

            try
            {
                _serviceHost.Close();                
            }
            catch (Exception)
            {
                ConsoleController.Write("Cannot stop authorization service.");
                return;
            }

            ConsoleController.Write("Authorization service stopped.");
        }
    }
}