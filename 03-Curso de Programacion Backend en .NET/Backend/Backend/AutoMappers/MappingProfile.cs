using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>(); // Cuando se tienen los mismos nombres de campo con esto ya basta
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                            m => m.MapFrom(b => b.BeerId));
            CreateMap<BeerUpdateDto, Beer>();
        }
    }
}
