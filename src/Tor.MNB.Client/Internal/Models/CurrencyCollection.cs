using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    [CollectionDataContract(ItemName = "Curr", Namespace = "")]
    internal class CurrencyCollection : Collection<string> { }
}
