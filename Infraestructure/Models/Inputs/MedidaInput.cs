using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class MedidaInput : EntityBase
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int Profundidad { get; set; }
        public long ProductoId { get; set; }
    }
}
