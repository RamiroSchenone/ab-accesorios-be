using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class MedidaDto : DtoBase
    {
        public float Alto { get; set; }
        public float Ancho { get; set; }
        public float Profundidad { get; set; }
        public long ProductoId { get; set; }
    }
}
