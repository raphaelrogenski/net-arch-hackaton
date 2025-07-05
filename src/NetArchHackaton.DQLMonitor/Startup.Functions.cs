using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NetArchHackaton.DQLMonitor
{
    public partial class Startup
    {
        private void ConfigureFunctions(FunctionsApplicationBuilder builder)
        {
            builder.ConfigureFunctionsWebApplication();

            builder.Services.AddFunctionsWorkerDefaults();
        }
    }
}
