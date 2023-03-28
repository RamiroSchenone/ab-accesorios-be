using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using ab_accesorios_be.Infraestructure.Models.Inputs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var productosList = await _context.Productos
                .Include(x => x.Medidas)
                .Include(x => x.Marca).ToListAsync();

            var dtos = _mapper.Map<List<Producto>, List<ProductoDto>>(productosList);

            return dtos;
        }

        public async Task<ProductoDto> Get(int id)
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
            var entity = _mapper.Map<ProductoInput, Producto>(productoInput);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Producto, ProductoDto>(entity);

            return dto;
        }

        //public async Task<ProductoDto> Put(ProductoInput productoInput)
        //{

        //    Producto entity = await _context.Productos.FindAsync(productoInput.Id);

        //    if (entity == null)
        //    {
        //        return null; // O manejar el error de entidad no encontrada
        //    }

        //    // Actualizar solo las propiedades que se proporcionan en el objeto de entrada
        //    if (productoInput.Nombre != null)
        //    {
        //        entity.Nombre = productoInput.Nombre;
        //    }
        //    if (productoInput.Descripcion != null)
        //    {
        //        entity.Descripcion = productoInput.Descripcion;
        //    }
        //    if (productoInput.Disponible != default)
        //    {
        //        entity.Disponible = productoInput.Disponible;
        //    }
        //    if (productoInput.ImageURL != null)
        //    {
        //        entity.ImageURL = productoInput.ImageURL;
        //    }
        //    if (productoInput.MarcaId != default)
        //    {
        //        entity.MarcaId = productoInput.MarcaId;
        //    }
        //    if (productoInput.Precio != default)
        //    {
        //        entity.Precio = productoInput.Precio;
        //    }
        //    if (productoInput.Medidas != null && productoInput.Medidas.Any())
        //    {
        //        // Borrar las medidas existentes y agregar las nuevas
        //        entity.Medidas.Clear();
        //        foreach (var medidaDto in productoInput.Medidas)
        //        {
        //            var medida = _mapper.Map<MedidaDto, Medida>(medidaDto);
        //            entity.Medidas.Add(medida);
        //        }
        //    }

        //    // Guardar los cambios en la base de datos
        //    _context.Update(entity);
        //    await _context.SaveChangesAsync();

        //    // Mapear la entidad actualizada a un objeto DTO
        //    var dto = _mapper.Map<Producto, ProductoDto>(entity);

        //    //return dto;
        //}

        public async Task<bool> Delete(long id)
        {
            var producto = _context.Productos.Where(x => x.Id == id).FirstOrDefault();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
