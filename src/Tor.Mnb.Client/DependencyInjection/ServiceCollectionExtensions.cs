using Microsoft.Extensions.DependencyInjection;

namespace Tor.Mnb.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMnb(this IServiceCollection services)
        {
            services.AddScoped<IMnbClient, MnbClient>();
        }
    }
}