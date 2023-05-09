using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using AutoMapper;

namespace ab_accesorios_be.Services
{
    public class ArchivoAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArchivoAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\filesUpload");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\filesUpload", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
            }
            return filename;
        }

        public async Task<ArchivoDto> SaveChanges(IFormFile file, string fileName) {

            var entity = new Archivo();
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\filesUpload", fileName);

            if (file != null && fileName != null) { 
                entity.FechaCreacion = DateTime.Now;
                entity.FilePath = filepath;
                entity.DownloadName = file.FileName;
                entity.FileName = fileName;
                entity.Size = file.Length;
                entity.ContentType = file.ContentType;
            }

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Archivo, ArchivoDto>(entity);

            return dto;
        }
    }
}
