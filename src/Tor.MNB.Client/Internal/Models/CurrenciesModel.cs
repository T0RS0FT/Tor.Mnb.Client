using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    [DataContract(Name = "MNBCurrencies", Namespace = "")]
    internal class CurrenciesModel
    {
        [DataMember(Name = "Currencies")]
        public Currencies Currencies { get; set; }
    }

    [CollectionDataContract(ItemName = "Curr", Namespace = "")]
    public class Currencies : Collection<string> { }
}
