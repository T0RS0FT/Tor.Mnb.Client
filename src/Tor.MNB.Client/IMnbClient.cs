namespace Tor.MNB.Client
{
    public interface IMnbClient
    {
        Task<bool> HealthCheckAsync();

        Task<List<string>> GetCurrenciesAsync();
    }
}
