using NetArchHackaton.Shared.Contracts.Auth.DTOs;

namespace NetArchHackaton.Shared.Contracts.Auth.Commands
{
    public interface IRegisterEmployeeHandler
    {
        Task<bool> HandleAsync(RegisterEmployeeRequest request);
    }
}
