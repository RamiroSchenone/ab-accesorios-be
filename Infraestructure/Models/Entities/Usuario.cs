namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Usuario : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionNumero { get; set; }
        public long LocalidadId { get; set; }
        public Localidad? Localidad { get; set; }
    }
}
