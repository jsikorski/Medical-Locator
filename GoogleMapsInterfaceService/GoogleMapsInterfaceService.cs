using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Requests;

namespace GoogleMapsInterfaceService
{
    public class GoogleMapsInterfaceService : IGoogleMapsInterfaceService
    {
        private readonly IRequestsSender _requestsSender;

        public GoogleMapsInterfaceService()
        {
            _requestsSender = new RequestsSender();
        }

        // Constructor used for testing purposes
        public GoogleMapsInterfaceService(IRequestsSender requestsSender)
        {
            _requestsSender = requestsSender;
        }

        public GooglePlacesApiResponse SendGooglePlacesApiRequest(GooglePlacesApiRequest request)
        {
            string responseJson = _requestsSender.SendRequest(request);
            return GetDeserializedDataFromJson<GooglePlacesApiResponse>(responseJson);
        }

        private T GetDeserializedDataFromJson<T>(string jsonString)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(jsonString);
        }
    }
}
