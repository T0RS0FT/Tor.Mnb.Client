using Microsoft.AspNetCore.Components;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class ExchangeRates
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private DateOnly startDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(-3));
        private DateOnly endDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        private string currencyCodes { get; set; }

        private List<ExchangeRatesResult> items = [];
        private bool hasData = false;

        private async Task LoadData()
        {
            this.items = await MnbClient.GetExchangeRatesAsync(
                this.startDate,
                this.endDate,
                this.currencyCodes?.Split(',')?.ToList() ?? []);
            this.hasData = this.items?.Count > 0;
        }
    }
}
