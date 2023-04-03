using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Mvc;

namespace ab_accesorios_be.Controllers
{
    [Route("api/marcas")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        protected readonly MarcaAppService appService;

        public MarcaController(MarcaAppService appService)
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
                var Marca = await this.appService.Get(id);
                if (Marca == null)
                {
                    return NotFound();
                }
                return Ok(Marca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarcaDto MarcaInput)
        {
            try
            {
                var MarcaUpdated = await this.appService.Post(MarcaInput);
                return Ok(new { message = "Marca creada con éxito.", entity = MarcaUpdated });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Put([FromBody] MarcaDto marcaInput)
        {
            try
            {
                var MarcaToUpdate = this.appService.Get(marcaInput.Id).Result;

                if (MarcaToUpdate == null)
                {
                    return NotFound();
                }

                var MarcaUpdated = await this.appService.Put(marcaInput);
                return Ok(new { message = "Marca actualizada con éxito.", entity = MarcaUpdated });
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
                    return Ok(new { message = "Marca eliminada con éxito." });

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
