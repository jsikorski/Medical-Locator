using System;

namespace ServicesHost
{
    public static class HostsBootstrapper
    {
        private static AuthorizationServiceHost _authorizationServiceHost;

        public static void Run()
        {
            _authorizationServiceHost = new AuthorizationServiceHost();
            StartService(_authorizationServiceHost, "Cannot start authorization service.");

            Console.ReadKey();

            StopService(_authorizationServiceHost, "Cannot stop authorization service.");
            Console.ReadKey();
        }

        private static void StartService(IServiceHost serviceHost, string errorMessage)
        {
            if (serviceHost.IsServiceRunning)
            {
                return;
            }

            try
            {
                serviceHost.StartService();
            }
            catch (Exception exception)
            {
                HandleException(errorMessage, exception);
            }
        }

        private static void StopService(IServiceHost serviceHost, string errorMessage)
        {
            if (!serviceHost.IsServiceRunning)
            {
                return;
            }

            try
            {
                serviceHost.StopService();
            }
            catch (Exception exception)
            {
                HandleException(errorMessage, exception);
            }
        }

        private static void HandleException(string errorMessage, Exception exception)
        {
            ConsoleController.Write(errorMessage);
            ConsoleController.Write(string.Format("Exception: {0}", exception.Message));
            ConsoleController.Write(string.Format("Inner exception: {0}", exception.InnerException));
        }
    }
}