using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using ab_accesorios_be.Infraestructure.Models.Inputs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ab_accesorios_be.Services
{
    public class ProductoAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductoAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> Get()
        {
            try
            {
                var productosList = await _context.Productos
                                .Include(x => x.Medidas)
                                .Include(x => x.Marca).ToListAsync();

                var dtos = _mapper.Map<List<Producto>, List<ProductoDto>>(productosList);

                return dtos;
            }
            catch (DbUpdateException ex)
            {

                var sb = new StringBuilder();
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine($"InnerException: {ex.InnerException.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");

                throw new Exception(sb.ToString());
            }
        }

        public async Task<ProductoDto> Get(long id)
        {
            var producto = await _context.Productos
                .Include(x => x.Medidas)
                .Include(x => x.Marca)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<Producto, ProductoDto>(producto);

            return dto;
        }

        public async Task<ProductoDto> Post(ProductoInput productoInput)
        {
            try
            {
                Producto entity = _mapper.Map<ProductoInput, Producto>(productoInput);
                entity.FechaCreacion = DateTime.Now;

                _context.Productos.Add(entity);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<Producto, ProductoDto>(entity);

                return dto;
            }
            catch (DbUpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine($"InnerException: {ex.InnerException.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");

                throw new Exception(sb.ToString());
            }
        }

        public async Task<ProductoDto> Put(ProductoInput productoInput)
        {
            try
            {
                Producto? entity = await _context.Productos
                                .Include(x => x.Medidas)
                                .Where(x => x.Id == productoInput.Id)
                                .FirstOrDefaultAsync();

                if (entity != null)
                {
                    entity.Nombre = productoInput.Nombre;
                    entity.Descripcion = productoInput.Descripcion;
                    entity.Disponible = productoInput.Disponible;
                    entity.ImageURL = productoInput.ImageURL;
                    entity.MarcaId = productoInput.MarcaId;
                    entity.Precio = productoInput.Precio;

                    entity.Medidas.Ancho = productoInput.Medidas.Ancho;
                    entity.Medidas.Alto = productoInput.Medidas.Alto;
                    entity.Medidas.Profudidad = productoInput.Medidas.Profudidad;

                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                var dto = _mapper.Map<Producto, ProductoDto>(entity);
                return dto;
            }
            catch (DbUpdateException ex)
            {

                var sb = new StringBuilder();
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine($"InnerException: {ex.InnerException.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");

                throw new Exception(sb.ToString());
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var producto = _context.Productos.Where(x => x.Id == id).FirstOrDefault();

                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateException ex)
            {

                var sb = new StringBuilder();
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine($"InnerException: {ex.InnerException.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");

                throw new Exception(sb.ToString());
            }
        }
    }
}
