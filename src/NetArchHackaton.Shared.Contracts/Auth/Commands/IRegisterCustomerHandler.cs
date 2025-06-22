using NetArchHackaton.Shared.Contracts.Auth.DTOs;

namespace NetArchHackaton.Shared.Contracts.Auth.Commands
{
    public interface IRegisterCustomerHandler
    {
        Task<bool> HandleAsync(RegisterCustomerRequest request);
    }
}
