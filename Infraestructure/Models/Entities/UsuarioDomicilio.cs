namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class UsuarioDomicilio : EntityBase
    {
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionNumero { get; set; }
        public Int64? CodigoPostal { get; set; }
        public long LocalidadGeoRefId { get; set; }
        public string LocalidadGeoRefDescripcion { get; set; }
        public long ProvinciaGeoRefId { get; set; }
        public string ProvinciaGeoRefDescripcion { get; set; }
    }
}
