namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Usuario : EntityBase
    {
        public int NroDocumento { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long LocalidadId { get; set; }
        public Localidad? Localidad { get; set; }
    }
}
