using System;
using System.ServiceModel;

namespace ServicesHost
{
    public static class ConsoleController
    {
         public static void Write(string message)
         {
             Console.WriteLine(message);
         }

        public static void ShowServiceHostEndpoints(ServiceHost serviceHost)
        {
            Write("Service endpoints: ");
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Write(string.Format("{0}: {1}", endpoint.Binding.Name, endpoint.ListenUri));
            }
        }
    }
}