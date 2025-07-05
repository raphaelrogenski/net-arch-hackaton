using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;

namespace NetArchHackaton.DQLMonitor
{
    public partial class Startup
    {
        public void Run(string[] args)
        {
            var builder = FunctionsApplication.CreateBuilder(args);

            ConfigureSettings(builder);
            ConfigureFunctions(builder);
            ConfigureInfrastructure(builder);

            var app = builder.Build();
            app.Run();
        }
    }
}
