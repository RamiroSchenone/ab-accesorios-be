using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models
{
    public class Producto : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Disponible { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public long MarcaId { get; set; }
        public Marca Marca { get; set; }
        [Required]
        public float Precio { get; set; }
        public ICollection<Medida> Medidas { get; }

        public DateTime FechaCreacion { get; set; }

        public Producto()
        {
            Medidas = new List<Medida>();
        }
    }

    public class Medida : EntityBase
    {
        [Required]
        public int Alto { get; set; }
        [Required]
        public int Ancho { get; set; }
        [Required]
        public int Profudidad { get; set; }
        public long ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
