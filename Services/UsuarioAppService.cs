﻿using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Services
{
    public class UsuarioAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UsuarioAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> Get()
        {
            var UsuariosList = await _context.Usuarios.ToListAsync();

            var dtos = _mapper.Map<List<Usuario>, List<UsuarioDto>>(UsuariosList);

            return dtos;
        }

        public async Task<UsuarioDto> Get(long id)
        {
            var Usuario = await _context.Usuarios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<Usuario, UsuarioDto>(Usuario);

            return dto;
        }

        public async Task<UsuarioDto> Post(UsuarioDto UsuarioInput)
        {
            var entity = _mapper.Map<UsuarioDto, Usuario>(UsuarioInput);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Usuario, UsuarioDto>(entity);

            return dto;
        }

        public async Task<UsuarioDto> Put(UsuarioDto UsuarioInput)
        {
            Usuario entity = await _context.Usuarios.FindAsync(UsuarioInput.Id);

            if (entity != null)
            {
                entity.Nombre = UsuarioInput.Nombre;
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<Usuario, UsuarioDto>(entity);
            return dto;
        }

        public async Task<bool> Delete(long id)
        {
            var Usuario = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
