using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Requests;

namespace GoogleMapsInterfaceService
{
    [ServiceContract]
    public interface IGoogleMapsInterfaceService
    {
        [OperationContract]
        GooglePlacesApiResponse SendGooglePlacesApiRequest(GooglePlacesApiRequest request);
    }
}
