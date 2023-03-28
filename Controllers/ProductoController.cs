using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Inputs;
using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<ProductoController>
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

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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

        // POST api/<ProductoController>
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

        // PUT api/<ProductoController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(long id, [FromBody] ProductoInput producto)
        //{
        //    try
        //    {
        //        if (id != producto.Id)
        //        {
        //            return BadRequest();
        //        }

        //        var productoUpdated = await this.appService.Put(producto);
        //        return Ok(productoUpdated);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // DELETE api/<ProductoController>/5
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
