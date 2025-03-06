using Tor.MNB.Client.Models;

namespace Tor.MNB.Client
{
    public interface IMnbClient
    {
        Task<bool> HealthCheckAsync();

        Task<List<string>> GetCurrenciesAsync();

        Task<GetInfoResult> GetInfoAsync();

        Task<List<CurrencyUnitResult>> GetCurrencyUnitsAsync(List<string> currencyCodes);

        Task GetDateIntervalAsync();

        Task GetExchangeRatesAsync(DateOnly startDate, DateOnly endDate, List<string> currencyCodes);

        Task GetCurrentExchangeRatesAsync();
    }
}
