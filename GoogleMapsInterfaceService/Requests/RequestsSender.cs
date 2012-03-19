using System.Net;

namespace GoogleMapsInterfaceService.Requests
{
    public class RequestsSender : IRequestsSender
    {
        public string SendRequest(IRequest request)
        {
            string requestUrl = request.ToRequestUrl();
            
            var webClient = new WebClient();
            string response = webClient.DownloadString(requestUrl);
            return response;
        }
    }
}