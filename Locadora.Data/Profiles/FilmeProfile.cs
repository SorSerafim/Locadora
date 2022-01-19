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
            CreateMap<Filme, ReadFilmeDto>().ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero.Nome));
            CreateMap<Filme, ReadFilmeComDiretorDto>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero.Nome))
                .ForMember(dest => dest.Diretor, opt => opt.MapFrom(src => src.Diretor.Nome));
        }
    }
}
