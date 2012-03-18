namespace ServicesHost
{
    public static class HostsBootstrapper
    {
        private static AuthorizationServiceHost _authorizationServiceHost;

        public static void Run()
        {
            _authorizationServiceHost = new AuthorizationServiceHost();
            _authorizationServiceHost.StartService();
        }
    }
}