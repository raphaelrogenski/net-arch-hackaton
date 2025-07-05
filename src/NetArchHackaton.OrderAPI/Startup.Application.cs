using NetArchHackaton.Shared.Application.Orders.Commands;
using NetArchHackaton.Shared.Application.Orders.Queries;
using NetArchHackaton.Shared.Application.Orders.Validators;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.Queries;

namespace NetArchHackaton.OrderAPI
{
    public partial class Startup
    {
        private void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGetOrdersHandler, GetOrdersHandler>();
            builder.Services.AddScoped<IGetOrderByIdHandler, GetOrderByIdHandler>();
            builder.Services.AddScoped<IProduceCreateOrderHandler, ProduceCreateOrderHandler>();
            builder.Services.AddScoped<IProduceCancelOrderHandler, ProduceCancelOrderHandler>();

            builder.Services.AddScoped<OnCreateOrderValidator>();
            builder.Services.AddScoped<OnCancelOrderValidator>();
        }
    }
}
