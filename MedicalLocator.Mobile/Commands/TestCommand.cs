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
                                      Key = "AIzaSyBT0QSMKebiRxchKcntQrbvRATIXcSm4cM",
                                      IsGpsUsed = true,
                                      Location = new Location {Lat = 50.0, Lng = 45.0},
                                      Radius = 10,
                                      MedicalTypes = new ObservableCollection<MedicalType> {MedicalType.Dentist}
                                  };

                var client = new GoogleMapsInterfaceServiceClient();
                GooglePlacesApiResponse response = client.SendGooglePlacesApiRequest(request);

                //client.SendGooglePlacesApiRequestAsync(new GooglePlacesApiRequest());

            }
        }

        private void ClientOnSendGooglePlacesApiRequestCompleted(object sender, SendGooglePlacesApiRequestCompletedEventArgs sendGooglePlacesApiRequestCompletedEventArgs)
        {
            //sendGooglePlacesApiRequestCompletedEventArgs.Result.
        }
    }
}