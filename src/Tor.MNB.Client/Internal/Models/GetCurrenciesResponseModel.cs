using System.Xml.Serialization;

namespace Tor.Mnb.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBCurrencies")]
    public class GetCurrenciesResponseModel
    {
        [XmlElement(ElementName = "Currencies")]
        public CurrencyCollectionModel Currencies { get; set; }
    }
}
