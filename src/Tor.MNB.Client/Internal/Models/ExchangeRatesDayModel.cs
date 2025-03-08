using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Day")]
    public class ExchangeRatesDayModel
    {
        [XmlElement(ElementName = "Rate")]
        public List<ExchangeRateModel> Rates { get; set; }

        [XmlAttribute(AttributeName = "date")]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Rate")]
    public class ExchangeRateModel
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }

        [XmlAttribute(AttributeName = "curr")]
        public string CurrencyCode { get; set; }

        [XmlText]
        public string ExchangeRate { get; set; }
    }
}
