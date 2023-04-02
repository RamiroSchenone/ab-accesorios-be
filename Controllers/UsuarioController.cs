using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Services;
using Microsoft.AspNetCore.Mvc;

namespace ab_accesorios_be.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected readonly UsuarioAppService appService;

        public UsuarioController(UsuarioAppService appService)
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
                var Usuario = await this.appService.Get(id);
                if (Usuario == null)
                {
                    return NotFound();
                }
                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto UsuarioInput)
        {
            try
            {
                var UsuarioUpdated = await this.appService.Post(UsuarioInput);
                return Ok(UsuarioUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UsuarioDto UsuarioInput)
        {
            try
            {
                if (id != UsuarioInput.Id)
                {
                    return BadRequest();
                }

                var UsuarioToUpdate = this.appService.Get(id).Result;

                if (UsuarioToUpdate == null)
                {
                    return NotFound();
                }

                var UsuarioUpdated = await this.appService.Put(UsuarioInput);
                return Ok(UsuarioUpdated);
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
                    return Ok(new { message = "Usuario eliminado con éxito." });

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
