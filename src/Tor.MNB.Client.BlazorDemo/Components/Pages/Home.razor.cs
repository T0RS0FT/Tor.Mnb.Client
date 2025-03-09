using Microsoft.AspNetCore.Components;

namespace Tor.Mnb.Client.BlazorDemo.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private IMnbClient MnbClient { get; set; }

        private string logs = string.Empty;

        private async Task HealthCheck()
        {
            var result = await MnbClient.HealthCheckAsync();

            logs += result
                ? $"Service is available{Environment.NewLine}"
                : $"Service is not available{Environment.NewLine}";
        }
    }
}
