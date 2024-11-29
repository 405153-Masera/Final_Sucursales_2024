using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sucursal, SucursalDto>().ReverseMap();
            CreateMap<Configuracion, ConfiguracionDto>().ReverseMap();
        }
    }
}
