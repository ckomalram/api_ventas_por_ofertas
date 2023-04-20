using api_ventas_por_oferta.Core.Entity;
using AutoMapper;

namespace api_ventas_por_oferta.Core.Dto;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auto, AutoResponseDto>();

        //.. si se desea mappear otra entidad, puedes colocarla aqui....
    }
}