using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class UsuarioDto : DtoBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get { return this.Nombre.ToLower().Substring(0, 1) + " " + this.Apellido.ToLower(); } }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionNumero { get; set; }
        public long LocalidadId { get; set; }
        public LocalidadDto? Localidad { get; set; }
    }
}
