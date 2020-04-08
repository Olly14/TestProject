using AutoMapper;
using Web.Api.Domain;
using Web.Api.DtoModels;

namespace Web.Api.ModelMappers.AppUserMappers
{
    public class AppUserDtoAutoMapperProfile : Profile
    {
        public AppUserDtoAutoMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            //CreateMap<RegistrationViewModel, AppUserViewModel>().ReverseMap();
            //CreateMap<RegistrationViewModel, AppUser>().ReverseMap();
            //CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }

    }
}
