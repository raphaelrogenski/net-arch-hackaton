using Microsoft.Extensions.Hosting;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        public void Run(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            ConfigureSettings(builder);

            ConfigureInfrastructure(builder);
            ConfigureApplication(builder);
            ConfigureHostedServices(builder);

            var app = builder.Build();

            UsePrometheus(app);

            app.Run();
        }
    }
}
