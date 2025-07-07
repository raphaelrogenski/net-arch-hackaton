using NetArchHackaton.Shared.Application.Kitchen.Commands;
using NetArchHackaton.Shared.Application.Kitchen.Queries;
using NetArchHackaton.Shared.Contracts.Kitchen.Commands;
using NetArchHackaton.Shared.Contracts.Kitchen.Queries;

namespace NetArchHackaton.KitchenAPI
{
    public partial class Startup
    {
        private void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGetKitchenOrdersHandler, GetKitchenOrdersHandler>();
            builder.Services.AddScoped<IAcceptKitchenOrderHandler, AcceptKitchenOrderHandler>();
            builder.Services.AddScoped<IRejectKitchenOrderHandler, RejectKitchenOrderHandler>();
            builder.Services.AddScoped<IFinishKitchenOrderHandler, FinishKitchenOrderHandler>();
        }
    }
}
