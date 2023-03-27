using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Services
{
    public class ProductoService
    {
        private readonly ApplicationDbContext _context;
        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> Get()
        {
            var productosList = await _context.Productos
                .Include(x => x.Medidas)
                .Include(x => x.Marca).ToListAsync();

            return productosList;
        }
    }
}
