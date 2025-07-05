using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;

namespace NetArchHackaton.DQLMonitor
{
    public partial class Startup
    {
        private void ConfigureSettings(FunctionsApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
            builder.Configuration.AddEnvironmentVariables();
        }
    }
}
