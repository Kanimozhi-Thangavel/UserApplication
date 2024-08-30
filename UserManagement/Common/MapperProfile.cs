using AutoMapper;
using UserManagement.DTO.User;
using UserManagement.Models;

namespace UserManagement.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }

    }
}
