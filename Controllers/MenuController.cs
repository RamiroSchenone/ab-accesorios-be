using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Mvc;

namespace ab_accesorios_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        protected readonly MenuAppService appService;

        public MenuItemController(MenuAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dtos = await this.appService.Get();
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var MenuItem = await this.appService.Get(id);
                if (MenuItem == null)
                {
                    return NotFound();
                }
                return Ok(MenuItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MenuItemDto MenuItemInput)
        {
            try
            {
                var MenuItemUpdated = await this.appService.Post(MenuItemInput);
                return Ok(MenuItemUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] MenuItemDto MenuItemInput)
        {
            try
            {
                if (id != MenuItemInput.Id)
                {
                    return BadRequest();
                }

                var MenuItemToUpdate = this.appService.Get(id).Result;

                if (MenuItemToUpdate == null)
                {
                    return NotFound();
                }

                var MenuItemUpdated = await this.appService.Put(MenuItemInput);
                return Ok(MenuItemUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var deleted = await appService.Delete(id);

                if (deleted)
                    return Ok(new { message = "MenuItem eliminado con éxito." });

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
