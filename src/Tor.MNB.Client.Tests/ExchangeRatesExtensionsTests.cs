using Tor.Mnb.Client.Extensions;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.Tests
{
    [TestClass]
    public class ExchangeRatesExtensionsTests
    {
        [DataTestMethod]
        [DataRow("EUR", "EUR", 1, true, 1)]
        [DataRow("eur", "EUR", 1, true, 1)]
        [DataRow("EUR", "eur", 1, true, 1)]
        [DataRow("eur", "eur", 1, true, 1)]
        [DataRow("EUR", "EUR", 10, true, 10)]
        [DataRow("EUR", "USD", 1, true, 1.04)]
        [DataRow("EUR", "USD", 2, true, 2.08)]
        [DataRow("USD", "EUR", 1, true, 0.96)]
        [DataRow("USD", "EUR", 5, true, 4.8)]
        [DataRow("USD", "GBP", 1, true, 0.81)]
        [DataRow("USD", "GBP", 10, true, 8.17)]
        [DataRow("USD", "USB", 1, false, 0)]
        [DataRow("USB", "USC", 1, false, 0)]
        [DataRow("USB", "USD", 1, false, 0)]
        [DataRow("", "USD", 1, false, 0)]
        [DataRow("USD", "", 1, false, 0)]
        [DataRow("", "", 1, false, 0)]
        [DataRow(null, "USD", 1, false, 0)]
        [DataRow("USD", null, 1, false, 0)]
        [DataRow(null, null, 1, false, 0)]
        [DataRow("  ", "USD", 1, false, 0)]
        [DataRow("USD", "   ", 1, false, 0)]
        [DataRow("  ", "    ", 1, false, 0)]
        public void ExchangeRatesExtensionsConvertTest(
            string sourceCurrencyCode,
            string destinationCurrencyCode,
            double amount,
            bool success,
            double expectedResult)
        {
            var rates = new ExchangeRatesResult()
            {
                BaseCurrencyCode = "EUR",
                Rates =
                [
                    new ExchangeRateResult(){ CurrencyCode="USD", ExchangeRate=(decimal)0.9615, Unit=1 },
                    new ExchangeRateResult(){ CurrencyCode="GBP", ExchangeRate=(decimal)1.1764, Unit=1 }
                ]
            };

            try
            {
                var result = rates.Convert(sourceCurrencyCode, destinationCurrencyCode, (decimal)amount);

                Assert.IsTrue(Math.Abs((decimal)expectedResult - result) < 0.01m);
            }
            catch (Exception ex)
            {
                if (success)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }
    }
}
