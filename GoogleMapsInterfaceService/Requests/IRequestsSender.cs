namespace GoogleMapsInterfaceService.Requests
{
    public interface IRequestsSender
    {
        string SendRequest(IRequest request);
    }
}