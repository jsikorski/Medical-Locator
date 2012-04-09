using System;
using System.Threading;
using System.Windows;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Infrastructure
{
    public static class SyncCommunicationExtensions
    {
        public static GooglePlacesWcfResponse SendGooglePlacesApiRequest(
            this GoogleMapsInterfaceServiceClient client, GooglePlacesApiRequest request)
        {
            var syncProvider = new ManualResetEvent(false);
            GooglePlacesWcfResponse response = null;
            client.SendGooglePlacesApiRequestCompleted += (sender, args) =>
                                                              {
                                                                  syncProvider.Set();

                                                                  try
                                                                  {
                                                                      response = args.Result;
                                                                  }
                                                                  catch
                                                                  {
                                                                  }
                                                              };
            client.SendGooglePlacesApiRequestAsync(request);
            syncProvider.WaitOne();
            CheckResponse(response);
            return response;
        }

        private static void CheckResponse(object response)
        {
            if (response == null)
            {
                throw new WcfConnectionErrorException();
            }
        }
    }
}