﻿using AutoMapper;
using Entity.Concrete;
using Entity.Dto;

namespace WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserRegisterDto>().ReverseMap();
        }
    }
}
