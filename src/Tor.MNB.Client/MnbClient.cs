using ServiceReference;
using Tor.MNB.Client.Extensions;
using Tor.MNB.Client.Helper;
using Tor.MNB.Client.Internal;
using Tor.MNB.Client.Internal.Models;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client
{
    public class MnbClient : IMnbClient
    {
        private readonly MNBArfolyamServiceSoapClient client = new();

        public async Task<bool> HealthCheckAsync() => (await this.GetCurrenciesAsync())?.Count > 0;

        public async Task<List<string>> GetCurrenciesAsync()
        {
            var response = await client.GetCurrenciesAsync(new GetCurrenciesRequestBody());

            var result = XmlHelper.DeserializeXml<GetCurrenciesResponseModel>(response.GetCurrenciesResponse1.GetCurrenciesResult);

            return Mappers.Currencies(result);
        }

        public async Task<GetInfoResult> GetInfoAsync()
        {
            var response = await client.GetInfoAsync(new GetInfoRequestBody());

            var result = XmlHelper.DeserializeXml<GetInfoResponseModel>(response.GetInfoResponse1.GetInfoResult);

            return Mappers.Info(result);
        }

        public async Task<List<CurrencyUnitResult>> GetCurrencyUnitsAsync(List<string> currencyCodes)
        {
            if (currencyCodes == null || currencyCodes.Count == 0)
            {
                return [];
            }

            var response = await client.GetCurrencyUnitsAsync(new GetCurrencyUnitsRequestBody()
            {
                currencyNames = string.Join(",", currencyCodes)
            });

            var result = XmlHelper.DeserializeXml<GetCurrencyUnitsResponseModel>(response.GetCurrencyUnitsResponse1.GetCurrencyUnitsResult);

            return Mappers.CurrencyUnits(result);
        }

        // TODO
        public async Task GetDateIntervalAsync()
        {
            var response = await client.GetDateIntervalAsync(new GetDateIntervalRequestBody());
        }

        // TODO
        public async Task GetExchangeRatesAsync(DateOnly startDate, DateOnly endDate, List<string> currencyCodes)
        {
            var response = await client.GetExchangeRatesAsync(new GetExchangeRatesRequestBody()
            {
                startDate = startDate.ToMnbFormat(),
                endDate = endDate.ToMnbFormat(),
                currencyNames = string.Join(",", currencyCodes)
            });
        }

        // TODO
        public async Task GetCurrentExchangeRatesAsync()
        {
            var response = await client.GetCurrentExchangeRatesAsync(new GetCurrentExchangeRatesRequestBody());
        }
    }
}
