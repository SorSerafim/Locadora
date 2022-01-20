using AutoMapper;
using FluentResults;
using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private IFilmeRepository _repository;
        private IMapper _mapper;

        public FilmeService(IFilmeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AdicionaFilme(CreateFilmeDto createDto)
        {
            _repository.Adiciona(_mapper.Map<Filme>(createDto));
        }

        public Result AtualizaFilme(int id, CreateFilmeDto createDto)
        {
            Filme filme = _repository.Retorna(id);
            if(filme != null)
            {
                filme.Nome = createDto.Nome;
                filme.Ano = createDto.Ano;
                filme.Duracao = createDto.Duracao;
                filme.DiretorId = createDto.DiretorId;
                filme.GeneroId = createDto.GeneroId;
                _repository.Atualiza(filme);
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado!");
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _repository.Retorna(id);
            if(filme != null)
            {
                _repository.Deleta(filme);
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado!");
        }

        public ReadFilmeComDiretorDto RetornaFilmePorId(int id)
        {
            Filme filme = _repository.Retorna(id);
            if (filme != null) return _mapper.Map<ReadFilmeComDiretorDto>(filme);
            return null;
        }

        public List<ReadFilmeComDiretorDto> RetornaListaDeFilmes()
        {
            return _mapper.Map<List<ReadFilmeComDiretorDto>>(_repository.RetornaLista());
        }

        public List<ReadFilmeComDiretorDto> RetornaListaDeFilmesPorNome(string name)
        {
            return _mapper.Map<List<ReadFilmeComDiretorDto>>(_repository.RetornaListaPorNome(name));
        }
    }
}
