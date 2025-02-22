using ServiceReference;
using Tor.MNB.Client.Helper;
using Tor.MNB.Client.Internal;
using Tor.MNB.Client.Internal.Models;

namespace Tor.MNB.Client
{
    public class MnbClient : IMnbClient
    {
        public async Task<List<string>> GetCurrenciesAsync()
        {
            var client = new MNBArfolyamServiceSoapClient();

            var response = await client.GetCurrenciesAsync(new GetCurrenciesRequestBody());

            var result = XmlHelper.DeserializeXml<CurrenciesModel>(response.GetCurrenciesResponse1.GetCurrenciesResult);

            return Mappers.Currencies(result);
        }
    }
}
