using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        private void ConfigureSettings(IHostBuilder host)
        {
            host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            });
        }
    }
}
