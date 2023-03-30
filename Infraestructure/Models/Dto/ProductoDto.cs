using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class ProductoDto : DtoBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string ImageURL { get; set; }
        public float Precio { get; set; }
        public long MarcaId { get; set; }

        public virtual MedidaDto? Medidas { get; set; }
        public virtual MarcaDto? Marca { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
