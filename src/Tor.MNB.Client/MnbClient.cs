using ServiceReference;
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
    }
}
