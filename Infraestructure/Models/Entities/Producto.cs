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
        public long MarcaId { get; set; }

        public virtual Marca? Marca { get; set; }

        public float Precio { get; set; }
        public ICollection<Medida> Medidas { get; }

        public DateTime FechaCreacion { get; set; }

        public Producto()
        {
            Medidas = new List<Medida>();
        }
    }
}
