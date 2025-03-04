namespace Tor.MNB.Client.Models
{
    public class GetInfoResult
    {
        public DateOnly FirstDate { get; set; }

        public DateOnly LastDate { get; set; }

        public List<string> CurrencyCodes { get; set; }
    }
}
