using System.Runtime.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    [DataContract(Name = "MNBCurrencies", Namespace = "")]
    internal class GetCurrenciesResponseModel
    {
        [DataMember(Name = "Currencies", Order = 0)]
        internal CurrencyCollection Currencies { get; set; }
    }
}
