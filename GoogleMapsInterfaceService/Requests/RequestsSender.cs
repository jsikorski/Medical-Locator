using System.Net;
using System.Text;

namespace GoogleMapsInterfaceService.Requests
{
    public class RequestsSender : IRequestsSender
    {
        public string SendRequest(IRequest request)
        {
            string requestUrl = request.ToRequestUrl();
            
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string response = webClient.DownloadString(requestUrl);
            return response;
        }
    }
}