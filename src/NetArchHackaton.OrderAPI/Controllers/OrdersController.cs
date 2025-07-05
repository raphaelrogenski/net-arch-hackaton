using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Contracts.Orders.Queries;
using System.Security.Claims;

namespace NetArchHackaton.MenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IGetOrdersHandler getHandler;
        private readonly IGetOrderByIdHandler getByIdHandler;
        private readonly IProduceCreateOrderHandler createHandler;
        private readonly IProduceCancelOrderHandler cancelHandler;

        public OrdersController(IGetOrdersHandler getHandler, IGetOrderByIdHandler getByIdHandler, IProduceCreateOrderHandler createHandler, IProduceCancelOrderHandler cancelHandler)
        {
            this.getHandler = getHandler;
            this.getByIdHandler = getByIdHandler;
            this.createHandler = createHandler;
            this.cancelHandler = cancelHandler;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userEmail = GetUserEmail();
                var result = await getHandler.HandleAsync(userEmail);

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

        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var userEmail = GetUserEmail();
                var result = await getByIdHandler.HandleAsync(userEmail, id);

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

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            try
            {
                var userEmail = GetUserEmail();
                await createHandler.HandleAsync(userEmail, request);

                return Ok("Request submitted successful!");
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

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Cancel(Guid id, CancelOrderRequest request)
        {
            try
            {
                var userEmail = GetUserEmail();
                await cancelHandler.HandleAsync(userEmail, id, request);

                return Ok("Request submitted successful!");
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
