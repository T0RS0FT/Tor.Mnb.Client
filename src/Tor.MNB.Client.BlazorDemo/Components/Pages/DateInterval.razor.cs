using Microsoft.AspNetCore.Components;
using Tor.MNB.Client.Models;

namespace Tor.MNB.Client.BlazorDemo.Components.Pages
{
    public partial class DateInterval
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private DateIntervalResult data;
        private bool hasData = false;

        private async Task LoadData()
        {
            this.data = await MnbClient.GetDateIntervalAsync();
            this.hasData = this.data != null;
        }
    }
}
