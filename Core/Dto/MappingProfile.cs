using api_ventas_por_oferta.Core.Entity;
using AutoMapper;

namespace api_ventas_por_oferta.Core.Dto;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Auto
        CreateMap<Auto, AutoResponseDto>();

        // Patio
        CreateMap<Patio, PatioResponseDto>();
        CreateMap<Patio, PatioAutoResponseDto>()
        .ForMember(dest => dest.Autos, opt => opt.MapFrom(
            src => src.Autos.Select(
                a => new AutoPatioResponseDto
                {
                    Id = a.Id,
                    Marca = a.Marca,
                    Modelo = a.Modelo,
                    Annio = a.Annio,
                    Precio = a.Precio,

                }
            )
        ));

        //.. si se desea mappear otra entidad, puedes colocarla aqui....
    }
}