﻿using System.Xml.Serialization;

namespace Tor.MNB.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "MNBCurrencies")]
    public class GetCurrenciesResponseModel
    {
        [XmlElement(ElementName = "Currencies")]
        public CurrencyCollectionModel Currencies { get; set; }
    }
}
