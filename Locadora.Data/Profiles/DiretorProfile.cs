using AutoMapper;
using Locadora.Domain;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Data.Profiles
{
    public class DiretorProfile : Profile
    {
        public DiretorProfile()
        {
            CreateMap<CreateDiretoresDto, Diretor>();
            CreateMap<Diretor, ReadDiretorDto>();
        }
    }
}
