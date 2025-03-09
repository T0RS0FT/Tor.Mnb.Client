using System.Xml.Serialization;

namespace Tor.Mnb.Client.Internal.Models
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
