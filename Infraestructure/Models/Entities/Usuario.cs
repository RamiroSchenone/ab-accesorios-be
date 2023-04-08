namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Usuario : EntityBase
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public UsuarioDomicilio UsuarioDomicilio { get; set; }
    }
}
