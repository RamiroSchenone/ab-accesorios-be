using System.ComponentModel.DataAnnotations;

namespace ab_accesorios_be.Infraestructure.Models
{
    public class Marca : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
    }
}
