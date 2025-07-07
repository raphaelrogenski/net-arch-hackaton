using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Application.Kitchen.Exceptions;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Kitchen.Commands;
using NetArchHackaton.Shared.Contracts.Kitchen.DTOs;
using NetArchHackaton.Shared.Contracts.Kitchen.Queries;
using System.Security.Claims;

namespace NetArchHackaton.MenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]/Orders")]
    public class KitchenController : ControllerBase
    {
        private readonly IGetKitchenOrdersHandler getHandler;
        private readonly IAcceptKitchenOrderHandler acceptHandler;
        private readonly IRejectKitchenOrderHandler rejectHandler;
        private readonly IFinishKitchenOrderHandler finishHandler;

        public KitchenController(IGetKitchenOrdersHandler getHandler, IAcceptKitchenOrderHandler acceptHandler, IRejectKitchenOrderHandler rejectHandler, IFinishKitchenOrderHandler finishHandler)
        {
            this.getHandler = getHandler;
            this.acceptHandler = acceptHandler;
            this.rejectHandler = rejectHandler;
            this.finishHandler = finishHandler;
        }

        [HttpGet]
        [Authorize(Roles = "Kitchen")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await getHandler.HandleAsync();

                return Ok(result);
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
                var result = await acceptHandler.HandleAsync(userEmail, id);

                return Ok(result);
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
                var result = await rejectHandler.HandleAsync(userEmail, id, cancelKitchenOrderRequest);

                return Ok(result);
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
                var result = await finishHandler.HandleAsync(userEmail, id);

                return Ok(result);
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
