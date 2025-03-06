using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBExchangeRatesQueryValues")]
    public class GetInfoResponseModel
    {
        [XmlElement(ElementName = "FirstDate")]
        public DateTime FirstDate { get; set; }

        [XmlElement(ElementName = "LastDate")]
        public DateTime LastDate { get; set; }

        [XmlElement(ElementName = "Currencies")]
        public CurrencyCollection Currencies { get; set; }
    }
}
