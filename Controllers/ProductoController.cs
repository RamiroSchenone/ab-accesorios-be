using ab_accesorios_be.Infraestructure.Models.Inputs;
using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Mvc;

namespace ab_accesorios_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        protected readonly ProductoAppService appService;

        public ProductoController(ProductoAppService appService)
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
                var producto = await this.appService.Get(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoInput productoInput)
        {
            try
            {
                var productoUpdated = await this.appService.Post(productoInput);
                return Ok(productoUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ProductoInput productoInput)
        {
            try
            {
                if (id != productoInput.Id)
                {
                    return BadRequest();
                }

                var productoToUpdate = this.appService.Get(id).Result;

                if (productoToUpdate == null)
                {
                    return NotFound();
                }

                var productoUpdated = await this.appService.Put(productoInput);
                return Ok(productoUpdated);
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
                    return Ok(new { message = "Producto eliminado con éxito." });

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
