using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Kitchen.DTOs;
using System.Security.Claims;

namespace NetArchHackaton.MenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]/Orders")]
    public class KitchenController : ControllerBase
    {
        public KitchenController()
        {
        }

        [HttpGet]
        [Authorize(Roles = "Kitchen")]
        public async Task<IActionResult> Get()
        {
            try
            {
                throw new NotImplementedException();
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

        [HttpPut("{id}/accept")]
        [Authorize(Roles = "Kitchen")]
        public async Task<IActionResult> Accept(Guid id)
        {
            try
            {
                var userEmail = GetUserEmail();
                throw new NotImplementedException();
            }
            catch (OrderNotFoundException)
            {
                return NotFound();
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

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "Kitchen")]
        public async Task<IActionResult> Reject(Guid id, CancelKitchenOrderRequest cancelKitchenOrderRequest)
        {
            try
            {
                var userEmail = GetUserEmail();
                throw new NotImplementedException();
            }
            catch (OrderNotFoundException)
            {
                return NotFound();
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

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "Kitchen")]
        public async Task<IActionResult> Finish(Guid id)
        {
            try
            {
                var userEmail = GetUserEmail();
                throw new NotImplementedException();
            }
            catch (OrderNotFoundException)
            {
                return NotFound();
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

        private string GetUserEmail()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return email;
        }
    }
}
