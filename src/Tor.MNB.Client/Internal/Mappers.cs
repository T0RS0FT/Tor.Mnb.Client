using Tor.MNB.Client.Internal.Models;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<GetCurrenciesResponseModel, List<string>> Currencies = x =>
            x.Currencies?.CurrencyCodes ?? [];

        internal static readonly Func<GetInfoResponseModel, GetInfoResult> Info = x =>
            new GetInfoResult()
            {
                FirstDate = DateOnly.FromDateTime(x.FirstDate),
                LastDate = DateOnly.FromDateTime(x.LastDate),
                CurrencyCodes = x.Currencies?.CurrencyCodes ?? []
            };

        internal static readonly Func<GetCurrencyUnitsResponseModel, List<CurrencyUnitResult>> CurrencyUnits = x =>
            x.UnitsCollection?.Items?.Select(x => new CurrencyUnitResult()
            {
                CurrencyCode = x.CurrencyCode,
                Unit = x.Unit
            }).ToList() ?? [];
    }
}
