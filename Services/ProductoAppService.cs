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
            var entity = _mapper.Map<ProductoInput, Producto>(productoInput);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Producto, ProductoDto>(entity);

            return dto;
        }

        public async Task<ProductoDto> Put(ProductoInput productoInput)
        {
            Producto entity = await _context.Productos.FindAsync(productoInput.Id);

            if (entity != null)
            {
                entity.Nombre = productoInput.Nombre;
                entity.Descripcion = productoInput.Descripcion;
                entity.Disponible = productoInput.Disponible;
                entity.ImageURL = productoInput.ImageURL;
                entity.MarcaId = productoInput.MarcaId;
                entity.Precio = productoInput.Precio;

                foreach (var medidaToUpdate in entity.Medidas)
                {
                    foreach (var medidaInput in productoInput.Medidas)
                    {
                        if (medidaToUpdate.ProductoId == medidaInput.ProductoId)
                        {
                            medidaToUpdate.Ancho = medidaInput.Ancho;
                            medidaToUpdate.Alto = medidaInput.Alto;
                            medidaToUpdate.Profudidad = medidaInput.Profudidad;
                        }
                    }
                }

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            var dto = _mapper.Map<Producto, ProductoDto>(entity);
            return dto;
        }

        public async Task<bool> Delete(long id)
        {
            var producto = _context.Productos.Where(x => x.Id == id).FirstOrDefault();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
