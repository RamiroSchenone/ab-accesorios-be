using ab_accesorios_be.Infraestructure.Data;
using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

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
            var UsuariosList = await _context.Usuarios.Include(x => x.UsuarioDomicilio)
                .ToListAsync();

            var dtos = _mapper.Map<List<Usuario>, List<UsuarioDto>>(UsuariosList);

            return dtos;
        }

        public async Task<UsuarioDto> Get(long id)
        {
            var Usuario = await _context.Usuarios
                .Include(x => x.UsuarioDomicilio)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<Usuario, UsuarioDto>(Usuario);

            return dto;
        }

        public async Task<UsuarioDto> Post(UsuarioDto UsuarioInput)
        {
            var entity = _mapper.Map<UsuarioDto, Usuario>(UsuarioInput);
            entity.FechaCreacion = DateTime.Now;
            entity.UsuarioDomicilio.FechaCreacion = DateTime.Now;
            entity.Username = entity.Nombre.ToLower().Substring(0, 1) + entity.Apellido.ToLower();

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
                entity.Apellido = UsuarioInput.Apellido;
                entity.Email = UsuarioInput.Email;
                entity.Telefono = UsuarioInput.Telefono;
                entity.Username = UsuarioInput.Nombre.ToLower().Substring(0, 1) + UsuarioInput.Apellido.ToLower();

                entity.UsuarioDomicilio.DireccionNumero = UsuarioInput.UsuarioDomicilio.DireccionNumero;
                entity.UsuarioDomicilio.DireccionCalle = UsuarioInput.UsuarioDomicilio.DireccionCalle;
                entity.UsuarioDomicilio.CodigoPostal = UsuarioInput.UsuarioDomicilio.CodigoPostal;
                entity.UsuarioDomicilio.ProvinciaGeoRefId = UsuarioInput.UsuarioDomicilio.ProvinciaGeoRefId;
                entity.UsuarioDomicilio.ProvinciaGeoRefDescripcion = UsuarioInput.UsuarioDomicilio.ProvinciaGeoRefDescripcion;
                entity.UsuarioDomicilio.LocalidadGeoRefId = UsuarioInput.UsuarioDomicilio.LocalidadGeoRefId;
                entity.UsuarioDomicilio.LocalidadGeoRefDescripcion = UsuarioInput.UsuarioDomicilio.LocalidadGeoRefDescripcion;
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
