using NetArchHackaton.Shared.Contracts.Kitchen.DTOs;

namespace NetArchHackaton.Shared.Contracts.Kitchen.Queries
{
    public interface IGetKitchenOrdersHandler
    {
        Task<IList<GetKitchenOrderResponse>> HandleAsync();
    }
}
