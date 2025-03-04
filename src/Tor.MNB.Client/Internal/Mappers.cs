using Tor.MNB.Client.Internal.Models;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<GetCurrenciesResponseModel, List<string>> Currencies = x =>
            x.Currencies?.ToList() ?? [];

        internal static readonly Func<GetInfoResponseModel, GetInfoResult> Info = x =>
            new GetInfoResult()
            {
                FirstDate = DateOnly.FromDateTime(x.FirstDate),
                LastDate = DateOnly.FromDateTime(x.LastDate),
                CurrencyCodes = x.Currencies?.ToList() ?? []
            };
    }
}
