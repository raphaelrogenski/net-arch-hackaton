using NetArchHackaton.Shared.Contracts.Auth.DTOs;

namespace NetArchHackaton.Shared.Contracts.Auth.Queries
{
    public interface ILoginHandler
    {
        Task<LoginResponse> HandleAsync(LoginRequest request);
    }
}
