using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class UsuarioDto : DtoBase
    {
        public int NroDocumento { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long LocalidadId { get; set; }
        public LocalidadDto? Localidad { get; set; }
    }
}
