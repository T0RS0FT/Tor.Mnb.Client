namespace Tor.MNB.Client.Models
{
    public class InfoResult
    {
        public DateOnly FirstDate { get; set; }

        public DateOnly LastDate { get; set; }

        public List<string> CurrencyCodes { get; set; }
    }
}
