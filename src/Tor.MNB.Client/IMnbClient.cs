namespace Tor.MNB.Client
{
    public interface IMnbClient
    {
        Task<List<string>> GetCurrenciesAsync();
    }
}
