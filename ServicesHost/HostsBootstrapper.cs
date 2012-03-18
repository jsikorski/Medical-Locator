using System;
using ServicesHost.Hosts;
using ServicesHost.Utils;

namespace ServicesHost
{
    public static class HostsBootstrapper
    {
        public static void Run()
        {
            var authorizationServiceHost = new AuthenticationServiceHost();
            StartService(authorizationServiceHost, "Cannot start authorization service.");
            ConsoleController.EmptyLine();
            var googleMapsInterfaceServiceHost = new GoogleMapsInterfaceServiceHost();
            StartService(googleMapsInterfaceServiceHost, "Cannot start Google Maps interface service.");
            ConsoleController.EmptyLine();

            Console.ReadKey();

            StopService(authorizationServiceHost, "Cannot stop authorization service.");
            ConsoleController.EmptyLine();
            StopService(googleMapsInterfaceServiceHost, "Cannot stop Google Maps interface service.");

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