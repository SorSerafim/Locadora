using AutoMapper;
using Locadora.Domain.Models;
using Locadora.Shared.CreateDto;
using Locadora.Shared.ReadDto;

namespace Locadora.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}
