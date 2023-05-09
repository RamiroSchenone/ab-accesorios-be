namespace ab_accesorios_be.Infraestructure.Models.Entities
{
    public class ArchivoDto : EntityBase
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DownloadName { get; set; }
        public string ContentType { get; set; }
        public Int64 Size { get; set; }
    }
}
