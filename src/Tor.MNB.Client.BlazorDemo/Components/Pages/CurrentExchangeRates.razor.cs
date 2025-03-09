using Microsoft.AspNetCore.Components;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class CurrentExchangeRates
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private ExchangeRatesResult data;
        private bool hasData = false;

        private async Task LoadData()
        {
            this.data = await MnbClient.GetCurrentExchangeRatesAsync();
            this.hasData = this.data != null;
        }
    }
}
