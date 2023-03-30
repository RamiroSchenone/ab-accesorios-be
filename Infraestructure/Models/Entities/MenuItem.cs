namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class MenuItem : EntityBase
    {
        public string Nombre { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string RedirectTo { get; set; }
    }

}
