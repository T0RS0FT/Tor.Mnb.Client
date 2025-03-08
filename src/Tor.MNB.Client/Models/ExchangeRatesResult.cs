namespace Tor.MNB.Client.Models
{
    public class ExchangeRatesResult
    {
        public DateOnly Date { get; set; }

        public List<ExchangeRateResult> Rates { get; set; }
    }
}
