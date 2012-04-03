﻿using System;
using System.Threading;
using System.Windows;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Infrastructure
{
    public static class SyncCommunicationExtensions
    {
        public static GooglePlacesApiResponse SendGooglePlacesApiRequest(
            this GoogleMapsInterfaceServiceClient client, GooglePlacesApiRequest request)
        {
            var syncProvider = new ManualResetEvent(false);
            GooglePlacesApiResponse response = null;
            client.SendGooglePlacesApiRequestCompleted += (sender, args) =>
                                                              {
                                                                  syncProvider.Set();
                                                                  response = args.Result;
                                                              };
            client.SendGooglePlacesApiRequestAsync(request);
            syncProvider.WaitOne();
            return response;
        }
    }
}