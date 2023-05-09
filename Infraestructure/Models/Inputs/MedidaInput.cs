using ab_accesorios_be.Infraestructure.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models.Inputs
{
    public class MedidasProductoInput : EntityBase
    {
        public float Alto { get; set; }
        public float Ancho { get; set; }
        public float Profundidad { get; set; }
        public long ProductoId { get; set; }
    }
}
