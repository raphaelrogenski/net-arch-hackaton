using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetArchHackaton.OrderService.Workers;
using NetArchHackaton.Shared.Application.Menu;
using NetArchHackaton.Shared.Contracts.Menu;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        private void ConfigureHostedServices(IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddHostedService<ConsumersWorker>();
            });
        }
    }
}
