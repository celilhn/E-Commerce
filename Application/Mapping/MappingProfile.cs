using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserAddDto>();
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<AdminUser, AdminUserAddDto>();
            CreateMap<AdminUserAddDto, AdminUser>();
            CreateMap<AdminUser, AdminUserUpdateDto>();
            CreateMap<AdminUserUpdateDto, AdminUser>();
        }
    }
}
