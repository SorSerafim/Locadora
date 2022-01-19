using AutoMapper;
using Locadora.Domain;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Data.Profiles
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<CreateGeneroDto, Genero>();
            CreateMap<Genero, ReadGeneroDto>();
        }
    }
}
