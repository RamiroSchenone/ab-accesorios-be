using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Services
{
    public class MarcaAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MarcaAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MarcaDto>> Get()
        {
            var MarcasList = await _context.Marcas.ToListAsync();

            var dtos = _mapper.Map<List<Marca>, List<MarcaDto>>(MarcasList);

            return dtos;
        }

        public async Task<MarcaDto> Get(long id)
        {
            var Marca = await _context.Marcas
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<Marca, MarcaDto>(Marca);

            return dto;
        }

        public async Task<MarcaDto> Post(MarcaDto MarcaInput)
        {
            var entity = _mapper.Map<MarcaDto, Marca>(MarcaInput);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Marca, MarcaDto>(entity);

            return dto;
        }

        public async Task<MarcaDto> Put(MarcaDto MarcaInput)
        {
            Marca entity = await _context.Marcas.FindAsync(MarcaInput.Id);

            if (entity != null)
            {
                entity.Nombre = MarcaInput.Nombre;
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Marca, MarcaDto>(entity);
            return dto;
        }

        public async Task<bool> Delete(long id)
        {
            var Marca = _context.Marcas.Where(x => x.Id == id).FirstOrDefault();
            _context.Marcas.Remove(Marca);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
