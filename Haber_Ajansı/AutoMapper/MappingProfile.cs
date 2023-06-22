using AutoMapper;
using Entity.Concrete;
using Entity.Dto;

namespace WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegisterDto, AppUser>().ReverseMap();
           // CreateMap<UserForRegisterDto, AppRole>().ReverseMap();
            CreateMap<UpdateUserDto, AppUser>().ReverseMap();
            CreateMap<CreateNewsDto, News>().ReverseMap();
           // CreateMap<UserLoginDto, AppUser>().ReverseMap();
            CreateMap<UserLoginDto, AppRole>().ReverseMap();
            CreateMap<CreateRoleDto, AppRole>().ReverseMap();
            CreateMap<UpdateRoleDto, AppRole>().ReverseMap();

        }
    }
}
