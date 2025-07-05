using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.MenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Cancel(Guid id, CancelOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
