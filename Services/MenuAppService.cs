using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Services
{
    public class MenuAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MenuAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MenuItemDto>> Get()
        {
            var MenuItemsList = await _context.Menus.ToListAsync();

            var dtos = _mapper.Map<List<MenuItem>, List<MenuItemDto>>(MenuItemsList);

            return dtos;
        }

        public async Task<MenuItemDto> Get(long id)
        {
            var MenuItem = await _context.Menus
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<MenuItem, MenuItemDto>(MenuItem);

            return dto;
        }

        public async Task<MenuItemDto> Post(MenuItemDto MenuItemInput)
        {
            var entity = _mapper.Map<MenuItemDto, MenuItem>(MenuItemInput);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<MenuItem, MenuItemDto>(entity);

            return dto;
        }

        public async Task<MenuItemDto> Put(MenuItemDto MenuItemInput)
        {
            MenuItem entity = await _context.Menus.FindAsync(MenuItemInput.Id);

            if (entity != null)
            {
                entity.Nombre = MenuItemInput.Nombre;
                entity.Label = MenuItemInput.Label;
                entity.Icon = MenuItemInput.Icon;
                entity.RedirectTo = MenuItemInput.RedirectTo;

            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<MenuItem, MenuItemDto>(entity);
            return dto;
        }

        public async Task<bool> Delete(long id)
        {
            var MenuItem = _context.Menus.Where(x => x.Id == id).FirstOrDefault();
            _context.Menus.Remove(MenuItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
