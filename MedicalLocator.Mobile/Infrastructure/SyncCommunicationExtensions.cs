using System;
using System.Threading;
using Caliburn.Micro;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.DatabaseConnectionReference;

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

        public static LoginResponse Login(
            this DatabaseConnectionServiceClient client, string login, string password)
        {
            var syncProvider = new ManualResetEvent(false);
            LoginResponse response = null;
            Exception responseException = null;
            client.LoginCompleted += (sender, args) =>
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
            client.LoginAsync(login, password);
            syncProvider.WaitOne();
            CheckException(responseException);
            return response;
        }

        public static RegisterResponse Register(
            this DatabaseConnectionServiceClient client, bool licenceAgree, string login, string password, string passwordRetype)
        {
            var syncProvider = new ManualResetEvent(false);
            RegisterResponse response = null;
            Exception responseException = null;
            client.RegisterCompleted += (sender, args) =>
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
            client.RegisterAsync(licenceAgree, login, password, passwordRetype);
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