using System.Xml.Serialization;

namespace Tor.Mnb.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBCurrencyUnits")]
    public class GetCurrencyUnitsResponseModel
    {
        [XmlElement(ElementName = "Units")]
        public CurrencyUnitsModel UnitsCollection { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Units")]
    public class CurrencyUnitsModel
    {
        [XmlElement(ElementName = "Unit")]
        public List<CurrencyUnitModel> Items { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "Unit")]
    public class CurrencyUnitModel
    {
        [XmlAttribute(AttributeName = "curr")]
        public string CurrencyCode { get; set; }

        [XmlText]
        public string Unit { get; set; }
    }
}
