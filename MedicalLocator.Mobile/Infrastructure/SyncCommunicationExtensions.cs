using System;
using System.Threading;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Infrastructure
{
    public static class SyncCommunicationExtensions
    {
        public static GooglePlacesWcfResponse SendGooglePlacesApiRequest(
            this GoogleMapsInterfaceServiceClient client, GooglePlacesApiRequest request)
        {
            var syncProvider = new ManualResetEvent(false);
            GooglePlacesWcfResponse response = null;
            Exception responseException = null;
            client.SendGooglePlacesApiRequestCompleted += (sender, args) =>
                                                              {
                                                                  syncProvider.Set();

                                                                  try
                                                                  {
                                                                      response = args.Result;
                                                                  }
                                                                  catch (Exception exception)
                                                                  {
                                                                      responseException = exception;
                                                                  }
                                                              };
            client.SendGooglePlacesApiRequestAsync(request);
            syncProvider.WaitOne();
            CheckException(responseException);
            return response;
        }

        private static void CheckException(Exception exception)
        {
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}