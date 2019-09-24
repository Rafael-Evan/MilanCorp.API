using AutoMapper;
using MilanCorp.API.Dtos;
using MilanCorp.Domain.Identity;

namespace MilanCorp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
