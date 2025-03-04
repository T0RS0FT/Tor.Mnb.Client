using Tor.MNB.Client.Helper;
using Tor.MNB.Client.Internal;
using Tor.MNB.Client.Internal.Models;

namespace Tor.MNB.Client.Tests
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
            Assert.IsTrue(result.LastDate > DateOnly.MinValue);
            Assert.IsTrue(result.CurrencyCodes.Count > 0);
            Assert.IsTrue(result.CurrencyCodes.All(x => !string.IsNullOrWhiteSpace(x)));
            Assert.IsTrue(result.CurrencyCodes.GroupBy(x => x).All(x => x.Count() == 1));
        }
    }
}
