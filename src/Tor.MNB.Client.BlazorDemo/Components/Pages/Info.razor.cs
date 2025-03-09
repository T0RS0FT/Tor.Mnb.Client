using Microsoft.AspNetCore.Components;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class Info
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private InfoResult info;
        private bool hasData = false;

        private async Task LoadData()
        {
            this.info = await MnbClient.GetInfoAsync();
            this.hasData = this.info?.CurrencyCodes?.Count > 0;
        }
    }
}
