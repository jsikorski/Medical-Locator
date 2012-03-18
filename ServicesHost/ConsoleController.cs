using System;
using System.ServiceModel;

namespace ServicesHost
{
    public static class ConsoleController
    {
         public static void ShowMessage(string message)
         {
             Console.WriteLine(message);
         }

        public static void ShowServiceHostEndpoints(ServiceHost serviceHost)
        {
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                ShowMessage(string.Format("{0}: {1}", endpoint.Binding, endpoint.ListenUri));
            }
        }
    }
}