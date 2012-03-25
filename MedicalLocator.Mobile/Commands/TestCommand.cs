using System;
using System.Collections.ObjectModel;
using System.Threading;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Commands
{
    public class TestCommand : ICommand
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public TestCommand(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public void Execute()
        {
            using (new BusyArea(_mainPageViewModel))
            {
                var request = new GooglePlacesApiRequest
                                  {
                                      Key = "111",
                                      IsGpsUsed = true,
                                      Location = new Location {Lat = 50.0, Lng = 45.0},
                                      Radius = 10,
                                      MedicalTypes = new ObservableCollection<MedicalType> {MedicalType.Dentist}
                                  };

                var client = new GoogleMapsInterfaceServiceClient();
                //client.SendGooglePlacesApiRequestAsync(new GooglePlacesApiRequest());
                RequestInvoker.InvokeSync<int>(
                    () => client.SendGooglePlacesApiRequestAsync(new GooglePlacesApiRequest()));
                
                client.SendGooglePlacesApiRequestCompleted += ClientOnSendGooglePlacesApiRequestCompleted;
                Thread.Sleep(5000);
            }
        }

        private void ClientOnSendGooglePlacesApiRequestCompleted(object sender, SendGooglePlacesApiRequestCompletedEventArgs sendGooglePlacesApiRequestCompletedEventArgs)
        {
            //sendGooglePlacesApiRequestCompletedEventArgs.Result.
        }
    }
}