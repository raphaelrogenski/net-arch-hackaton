using NetArchHackaton.Shared.Contracts.Auth.DTOs;

namespace NetArchHackaton.Shared.Contracts.Auth.Commands
{
    public interface IRegisterHandler
    {
        Task<bool> HandleAsync(RegisterRequest request);
    }
}
