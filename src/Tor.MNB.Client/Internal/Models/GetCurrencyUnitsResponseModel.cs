using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBCurrencyUnits")]
    public class GetCurrencyUnitsResponseModel
    {
        [XmlElement(ElementName = "Units")]
        public CurrencyUnits UnitsCollection { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Units")]
    public class CurrencyUnits
    {
        [XmlElement(ElementName = "Unit")]
        public List<CurrencyUnit> Items { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Unit")]
    public class CurrencyUnit
    {
        [XmlAttribute(AttributeName = "curr")]
        public string CurrencyCode { get; set; }

        [XmlText]
        public decimal Unit { get; set; }
    }
}
