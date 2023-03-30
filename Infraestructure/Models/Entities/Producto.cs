using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string ImageURL { get; set; }
        public float Precio { get; set; }

        [ForeignKey("Marca")]
        public long MarcaId { get; set; }

        public virtual Medida? Medidas { get; set; }
        public virtual Marca? Marca { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
