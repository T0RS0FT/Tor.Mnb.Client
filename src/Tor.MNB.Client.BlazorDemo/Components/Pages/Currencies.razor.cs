using Microsoft.AspNetCore.Components;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class Currencies
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private List<string> items = [];
        private bool hasData = false;

        private async Task LoadData()
        {
            this.items = await MnbClient.GetCurrenciesAsync();
            this.hasData = this.items?.Count > 0;
        }
    }
}
