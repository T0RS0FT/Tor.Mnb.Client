using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client
{
    public interface IMnbClient
    {
        string BaseCurrencyCode { get; }

        Task<bool> HealthCheckAsync();

        Task<List<string>> GetCurrenciesAsync();

        Task<InfoResult> GetInfoAsync();

        Task<List<CurrencyUnitResult>> GetCurrencyUnitsAsync(List<string> currencyCodes);

        Task<DateIntervalResult> GetDateIntervalAsync();

        Task<List<ExchangeRatesResult>> GetExchangeRatesAsync(DateOnly startDate, DateOnly endDate, List<string> currencyCodes);

        Task<ExchangeRatesResult> GetCurrentExchangeRatesAsync();
    }
}
