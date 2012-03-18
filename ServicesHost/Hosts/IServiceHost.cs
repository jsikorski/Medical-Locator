namespace ServicesHost.Hosts
{
    public interface IServiceHost
    {
        bool IsServiceRunning { get; }

        void StartService();
        void StopService();
    }
}