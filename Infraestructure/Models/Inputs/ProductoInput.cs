﻿using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Inputs
{
    public class ProductoInput : EntityBase
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string? ImageURL { get; set; }
        public long MarcaId { get; set; }
        public float Precio { get; set; }
        public ICollection<MedidaDto> Medidas { get; set; }

        public ProductoInput()
        {
            Medidas = new List<MedidaDto>();
        }
    }
}
