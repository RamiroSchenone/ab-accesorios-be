using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class UsuarioDto : DtoBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public long UsuarioDomicilioId { get; set; }
        public UsuarioDomicilioDto UsuarioDomicilio { get; set; }
    }
}
