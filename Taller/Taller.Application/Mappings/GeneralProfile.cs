using AutoMapper;
using Taller.Application.DTOs;
using Taller.Domain.Entities;

namespace Taller.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}