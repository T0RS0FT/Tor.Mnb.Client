using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBCurrentExchangeRates")]
    public class GetCurrentExchangeRatesResponseModel
    {
        [XmlElement(ElementName = "Day")]
        public ExchangeRatesDayModel Day { get; set; }
    }
}
