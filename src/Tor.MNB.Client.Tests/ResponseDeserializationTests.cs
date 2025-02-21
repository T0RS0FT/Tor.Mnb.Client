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

            var model = XmlHelper.DeserializeXml<CurrenciesModel>(xml);

            var result = Mappers.Currencies.Invoke(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.All(x => !string.IsNullOrWhiteSpace(x)));
            Assert.IsTrue(result.GroupBy(x => x).All(x => x.Count() == 1));
        }
    }
}
