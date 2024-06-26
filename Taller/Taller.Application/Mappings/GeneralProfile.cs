﻿using AutoMapper;
using Taller.Application.DTOs.Accounts;
using Taller.Application.DTOs.Client;
using Taller.Domain.Entities;

namespace Taller.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Client, ClientRequestDTO>()
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
                .ForMember(dir =>
                    dir.ClientState,
                    opt => opt.MapFrom(src => src.State))
                .ReverseMap();

            CreateMap<Client, ClientResponseDTO>()
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
                .ForMember(dir =>
                    dir.ClientState,
                    opt => opt.MapFrom(src => src.State))
                .ReverseMap();


            CreateMap<Account, AccountResponseDTO>()
                .ForMember(dir =>
                    dir.ClientName,
                    opt => opt.MapFrom(src => src.ClientNav.PersonNav.Name))
                .ReverseMap();
        }
    }
}