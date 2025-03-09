using Tor.Mnb.Client.Helper;
using Tor.Mnb.Client.Internal;
using Tor.Mnb.Client.Internal.Models;

namespace Tor.Mnb.Client.Tests
{
    [TestClass]
    public class ResponseDeserializationTests
    {
        [TestMethod]
        public void GetCurrenciesDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetCurrenciesResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetCurrenciesResponseModel>(xml);

            var result = Mappers.Currencies(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.All(x => !string.IsNullOrWhiteSpace(x)));
            Assert.IsTrue(result.GroupBy(x => x).All(x => x.Count() == 1));
        }

        [TestMethod]
        public void GetInfoDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetInfoResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetInfoResponseModel>(xml);

            var result = Mappers.Info(model);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CurrencyCodes);
            Assert.IsTrue(result.FirstDate > DateOnly.MinValue);
            Assert.IsTrue(result.FirstDate < DateOnly.MaxValue);
            Assert.IsTrue(result.LastDate > DateOnly.MinValue);
            Assert.IsTrue(result.LastDate < DateOnly.MaxValue);
            Assert.IsTrue(result.CurrencyCodes.Count > 0);
            Assert.IsTrue(result.CurrencyCodes.All(x => !string.IsNullOrWhiteSpace(x)));
            Assert.IsTrue(result.CurrencyCodes.GroupBy(x => x).All(x => x.Count() == 1));
        }

        [TestMethod]
        public void GetCurrencyUnitsDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetCurrencyUnitsResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetCurrencyUnitsResponseModel>(xml);

            var result = Mappers.CurrencyUnits(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.All(x => !string.IsNullOrWhiteSpace(x.CurrencyCode)));
            Assert.IsTrue(result.GroupBy(x => x.CurrencyCode).All(x => x.Count() == 1));
            Assert.IsTrue(result.All(x => x.Unit != 0));
        }

        [TestMethod]
        public void GetDateIntervalDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetDateIntervalResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetDateIntervalResponseModel>(xml);

            var result = Mappers.DateInterval(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.StartDate > DateOnly.MinValue);
            Assert.IsTrue(result.StartDate < DateOnly.MaxValue);
            Assert.IsTrue(result.EndDate > DateOnly.MinValue);
            Assert.IsTrue(result.EndDate < DateOnly.MaxValue);
        }

        [TestMethod]
        public void GetExchangeRatesDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetExchangeRatesResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetExchangeRatesResponseModel>(xml);

            var result = Mappers.ExchangeRates(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.GroupBy(x => x.Date).All(x => x.Count() == 1));
            Assert.IsTrue(result.All(x => x.Date > DateOnly.MinValue));
            Assert.IsTrue(result.All(x => x.Date < DateOnly.MaxValue));
            Assert.IsTrue(result.All(x => x.Rates.All(y => y.Unit != 0)));
            Assert.IsTrue(result.All(x => x.Rates.All(y => y.ExchangeRate != 0)));
            Assert.IsTrue(result.All(x => x.Rates.All(y => !string.IsNullOrWhiteSpace(y.CurrencyCode))));
            Assert.IsTrue(result.All(x => x.Rates.GroupBy(y => y.CurrencyCode).All(y => y.Count() == 1)));
            Assert.IsTrue(result.All(x => x.BaseCurrencyCode == Constants.BaseCurrencyCode));
        }

        [TestMethod]
        public void GetCurrentExchangeRatesDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "GetCurrentExchangeRatesResponse.xml"));

            var model = XmlHelper.DeserializeXml<GetCurrentExchangeRatesResponseModel>(xml);

            var result = Mappers.CurrentExchangeRates(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Date > DateOnly.MinValue);
            Assert.IsTrue(result.Date < DateOnly.MaxValue);
            Assert.IsTrue(result.Rates.All(x => x.Unit != 0));
            Assert.IsTrue(result.Rates.All(x => x.ExchangeRate != 0));
            Assert.IsTrue(result.Rates.All(x => !string.IsNullOrWhiteSpace(x.CurrencyCode)));
            Assert.IsTrue(result.Rates.GroupBy(x => x.CurrencyCode).All(y => y.Count() == 1));
            Assert.IsTrue(result.BaseCurrencyCode == Constants.BaseCurrencyCode);
        }
    }
}
