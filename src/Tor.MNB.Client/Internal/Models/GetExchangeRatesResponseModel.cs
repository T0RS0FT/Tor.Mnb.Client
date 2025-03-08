using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBExchangeRates")]
    public class GetExchangeRatesResponseModel
    {
        [XmlElement(ElementName = "Day")]
        public List<ExchangeRatesDayModel> Day { get; set; }
    }
}
