using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Medida : EntityBase
    {
        public float Alto { get; set; }
        public float Ancho { get; set; }
        public float Profundidad { get; set; }
        public long ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
