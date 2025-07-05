using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Infrastructure.Base.Messaging;

namespace NetArchHackaton.DQLMonitor
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(FunctionsApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMessageService, RabbitMQService>();
        }
    }
}
