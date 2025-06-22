using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Contracts.Auth.Queries;

namespace NetArchHackaton.AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginHandler loginHandler;
        private readonly IRegisterCustomerHandler registerCustomerHandler;
        private readonly IRegisterEmployeeHandler registerEmployeeHandler;

        public AuthController(ILoginHandler loginHandler, IRegisterCustomerHandler registerCustomerHandler, IRegisterEmployeeHandler registerEmployeeHandler)
        {
            this.loginHandler = loginHandler;
            this.registerCustomerHandler = registerCustomerHandler;
            this.registerEmployeeHandler = registerEmployeeHandler;
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

        [HttpPost("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerRequest request)
        {
            try
            {
                await registerCustomerHandler.HandleAsync(request);
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

        [HttpPost("RegisterEmployee")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeRequest request)
        {
            try
            {
                await registerEmployeeHandler.HandleAsync(request);
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
