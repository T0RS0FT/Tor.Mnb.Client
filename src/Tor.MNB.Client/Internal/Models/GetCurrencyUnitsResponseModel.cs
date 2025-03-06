using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    [DataContract(Name = "MNBCurrencyUnits", Namespace = "")]
    internal class GetCurrencyUnitsResponseModel
    {
        //[DataMember(Name = "Units", Order = 0)]
        //internal CurrencyUnitCollection Currencies { get; set; }

        [DataMember(Name = "Units", Order = 0)]
        internal Collection<A> Items { get; set; }
    }

    [CollectionDataContract(ItemName = "Unit", Namespace = "")]
    [XmlSerializerFormat]
    internal class CurrencyUnitCollection : Collection<decimal>
    {
        [XmlAttribute()]
        internal string CurrencyCode { get; set; }
    }

    [CollectionDataContract(ItemName = "Unit")]
    [XmlSerializerFormat]
    internal class A
    {
        [DataMember, XmlAttribute]
        internal string curr { get; set; }

        [DataMember, XmlText]
        internal string Value { get; set; }
    }
}
