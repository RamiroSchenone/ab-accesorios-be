using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Medida : EntityBase
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int Profudidad { get; set; }
        public long ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
