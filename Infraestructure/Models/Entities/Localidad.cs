namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Localidad : EntityBase
    {
        public string Descripcion { get; set; }
        public long ProvinciaId { get; set; }
        public Provincia? Provincia { get; set; }
        public int CodigoPostal { get; set; }

    }
}
