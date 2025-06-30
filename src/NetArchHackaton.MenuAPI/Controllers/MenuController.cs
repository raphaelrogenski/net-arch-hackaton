using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetArchHackaton.Shared.Application.Menu.Exceptions;
using NetArchHackaton.Shared.Contracts.Menu.Commands;
using NetArchHackaton.Shared.Contracts.Menu.DTOs;
using NetArchHackaton.Shared.Contracts.Menu.Queries;

namespace NetArchHackaton.MenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IGetMenuHandler getHandler;
        private readonly IGetMenuItemHandler getItemHandler;
        private readonly ICreateMenuItemHandler createItemHandler;
        private readonly IUpdateMenuItemHandler updateItemHandler;
        private readonly IDeleteMenuItemHandler deleteItemHandler;

        public MenuController(IGetMenuHandler getHandler, IGetMenuItemHandler getItemHandler, ICreateMenuItemHandler createItemHandler, IUpdateMenuItemHandler updateItemHandler, IDeleteMenuItemHandler deleteItemHandler)
        { 
            this.getHandler = getHandler;
            this.getItemHandler = getItemHandler;
            this.createItemHandler = createItemHandler;
            this.updateItemHandler = updateItemHandler;
            this.deleteItemHandler = deleteItemHandler;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] string? category, [FromQuery] bool? onlyAvailable, [FromQuery] string? search)
        {
            try
            {
                var request = new MenuRequest
                {
                    Category = category,
                    OnlyAvailable = onlyAvailable ?? true,
                    Search = search
                };

                var result = await getHandler.HandleAsync(request);
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
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await getItemHandler.HandleAsync(id);
                return Ok(result);
            }
            catch (MenuItemNotFoundException)
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
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(CommandMenuItemRequest request)
        {
            try
            {
                var id = await createItemHandler.HandleAsync(request);
                return CreatedAtAction(nameof(Get), new { id }, new { id });
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(Guid id, CommandMenuItemRequest request)
        {
            try
            {
                var success = await updateItemHandler.HandleAsync(id, request);
                return Ok();
            }
            catch (MenuItemNotFoundException)
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var success = await deleteItemHandler.HandleAsync(id);
                return Ok();
            }
            catch (MenuItemNotFoundException)
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
    }
}
