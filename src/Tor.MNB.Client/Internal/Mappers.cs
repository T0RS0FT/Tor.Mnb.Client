using Tor.MNB.Client.Internal.Models;

namespace Tor.MNB.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<CurrenciesModel, List<string>> Currencies = x =>
            x.Currencies?.ToList() ?? [];
    }
}
