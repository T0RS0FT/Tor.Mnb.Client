namespace Tor.Mnb.Client.Models
{
    public class ExchangeRatesResult
    {
        public string BaseCurrencyCode { get; set; }

        public DateOnly Date { get; set; }

        public List<ExchangeRateResult> Rates { get; set; }
    }

    public class ExchangeRateResult
    {
        public decimal Unit { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}
