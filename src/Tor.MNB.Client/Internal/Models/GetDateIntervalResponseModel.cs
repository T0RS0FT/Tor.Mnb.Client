using System.Xml.Serialization;

namespace Tor.Mnb.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBStoredInterval")]
    public class GetDateIntervalResponseModel
    {
        [XmlElement(ElementName = "DateInterval")]
        public DateIntervalModel DateInterval { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "DateInterval")]
    public class DateIntervalModel
    {
        [XmlAttribute(AttributeName = "startdate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute(AttributeName = "enddate")]
        public DateTime EndDate { get; set; }
    }
}
