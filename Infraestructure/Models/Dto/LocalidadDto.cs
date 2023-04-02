using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class LocalidadDto : DtoBase
    {
        public string Descripcion { get; set; }
        public long ProvinciaId { get; set; }
        public ProvinciaDto? Provincia { get; set; }
        public int CodigoPostal { get; set; }

    }
}
