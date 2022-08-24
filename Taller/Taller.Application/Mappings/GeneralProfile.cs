using AutoMapper;
using Taller.Application.DTOs;
using Taller.Domain.Entities;

namespace Taller.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Client, ClientDTO>()
                .ForMember(dir =>
                    dir.Address,
                    opt => opt.MapFrom(src => src.PersonNav.Address))
                .ForMember(dir =>
                    dir.Identification,
                    opt => opt.MapFrom(src => src.PersonNav.Identification))
                .ForMember(dir =>
                    dir.Name,
                    opt => opt.MapFrom(src => src.PersonNav.Name))
                .ForMember(dir =>
                    dir.Phone,
                    opt => opt.MapFrom(src => src.PersonNav.Phone))
                .ReverseMap();
        }
    }
}