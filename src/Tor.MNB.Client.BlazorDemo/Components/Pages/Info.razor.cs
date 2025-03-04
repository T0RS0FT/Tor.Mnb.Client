using Microsoft.AspNetCore.Components;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client.BlazorDemo.Components.Pages
{
    public partial class Info
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private GetInfoResult info;
        private bool hasData = false;

        private async Task LoadData()
        {
            this.info = await MnbClient.GetInfoAsync();
            this.hasData = this.info?.CurrencyCodes?.Count > 0;
        }
    }
}
