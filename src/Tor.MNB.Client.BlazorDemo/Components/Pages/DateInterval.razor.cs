using Microsoft.AspNetCore.Components;
using Tor.Mnb.Client.Models;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
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
