using AutoMapper;
using Locadora.Domain;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Data.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
