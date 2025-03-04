using System.Runtime.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    [DataContract(Name = "MNBExchangeRatesQueryValues", Namespace = "")]
    internal class GetInfoResponseModel
    {
        [DataMember(Name = "FirstDate", Order = 0)]
        internal DateTime FirstDate { get; set; }

        [DataMember(Name = "LastDate", Order = 1)]
        internal DateTime LastDate { get; set; }

        [DataMember(Name = "Currencies", Order = 2)]
        internal CurrencyCollection Currencies { get; set; }
    }
}
