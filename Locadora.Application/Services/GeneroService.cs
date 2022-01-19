using AutoMapper;
using FluentResults;
using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private IGeneroRepository _repository;
        private IMapper _mapper;

        public GeneroService(IGeneroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AdicionaGenero(CreateGeneroDto createDto)
        {
            _repository.Adiciona(_mapper.Map<Genero>(createDto));
        }

        public Result AtualizaGenero(int id, CreateGeneroDto createDto)
        {
            Genero genero = _repository.Retorna(id);
            if(genero != null)
            {
                genero.Nome = createDto.Nome;
                _repository.Atualiza(genero);
                return Result.Ok();
            }
            return Result.Fail("Gênero não encontrado!");
        }

        public Result DeletaGenero(int id)
        {
            Genero genero = _repository.Retorna(id);
            if(genero != null)
            {
                _repository.Deleta(genero);
                return Result.Ok();
            }
            return Result.Fail("Gênero não encontrado!");
        }

        public ReadGeneroDto RetornaGeneroPorId(int id)
        {
            Genero genero = _repository.Retorna(id);
            if (genero != null) return _mapper.Map<ReadGeneroDto>(genero);
            return null;
        }

        public List<ReadGeneroDto> RetornaListaDeGeneros()
        {
            return _mapper.Map<List<ReadGeneroDto>>(_repository.RetornaLista());
        }
    }
}
