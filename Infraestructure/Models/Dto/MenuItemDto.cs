using ab_accesorios_be.Infraestructure.Models.Entities;

namespace ab_accesorios_be.Infraestructure.Models.Dto
{
    public class MenuItemDto : DtoBase
    {
        public string Nombre { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string RedirectTo { get; set; }
    }
}
