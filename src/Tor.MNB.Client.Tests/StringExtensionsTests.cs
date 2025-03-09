using Tor.Mnb.Client.Extensions;

namespace Tor.Mnb.Client.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void StringToDecimalTest()
        {
            Assert.AreEqual(12.3456m, "12,3456".ToDecimal());
            Assert.AreEqual(12.3456m, "12.3456".ToDecimal());
        }
    }
}
