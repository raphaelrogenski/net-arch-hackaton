using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.Queries;

namespace NetArchHackaton.AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginHandler loginHandler;
        private readonly IRegisterHandler registerHandler;

        public AuthController(ILoginHandler loginHandler, IRegisterHandler registerHandler)
        {
            this.loginHandler = loginHandler;
            this.registerHandler = registerHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Shared.Contracts.Auth.DTOs.LoginRequest request)
        {
            try
            {
                var result = await loginHandler.HandleAsync(request);
                return Ok(result);
            }
            catch (Shared.Application.Base.Exceptions.ApplicationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterCustomer(Shared.Contracts.Auth.DTOs.RegisterRequest request)
        {
            try
            {
                await registerHandler.HandleAsync(request);
                return Created();
            }
            catch (Shared.Application.Base.Exceptions.ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
