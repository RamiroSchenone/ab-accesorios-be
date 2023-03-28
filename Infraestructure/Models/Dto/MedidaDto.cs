using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class MedidaDto : DtoBase
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int Profudidad { get; set; }
        public long ProductoId { get; set; }
    }
}
