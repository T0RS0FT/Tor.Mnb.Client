using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Currencies")]
    public class CurrencyCollectionModel
    {
        [XmlElement(ElementName = "Curr")]
        public List<string> CurrencyCodes { get; set; }
    }
}
