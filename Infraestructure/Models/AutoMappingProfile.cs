using ab_accesorios_be.Infraestructure.Models.Dto;
using ab_accesorios_be.Infraestructure.Models.Entities;
using ab_accesorios_be.Infraestructure.Models.Inputs;
using AutoMapper;

namespace ab_accesorios_be.Infraestructure.Models
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<ProductoInput, Producto>().ReverseMap();
            CreateMap<MedidaInput, Medida>().ReverseMap();
            CreateMap<Medida, MedidaDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioDomicilio, UsuarioDomicilioDto>().ReverseMap();
        }
    }
}
