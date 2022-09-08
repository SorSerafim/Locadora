using AutoMapper;
using FluentResults;
using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using MediatR;

namespace Locadora.Application.Services
{
    public class DiretorService : IDiretorService
    {
        private IDiretorRepository _repository;
        private IMapper _mapper;

        public DiretorService(IDiretorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AdicionaDiretor(CreateDiretoresDto createDto)
        {
            _repository.Adiciona(_mapper.Map<Diretor>(createDto));
        }

        public Result AtualizaDiretor(int id, CreateDiretoresDto createDto)
        {
            Diretor diretor = _repository.Retorna(id);
            if(diretor != null)
            {
                diretor.Nome = createDto.Nome;
                _repository.Atualiza(diretor);
                return Result.Ok();
            }
            return Result.Fail("Diretor não encontrado!");
        }

        public Result DeletaDiretor(int id)
        {
            Diretor diretor = _repository.Retorna(id);
            if (diretor != null)
            {
                _repository.Deleta(diretor);
                return Result.Ok();
            }
            return Result.Fail("Diretor não encontrado!");
        }

        public ReadDiretorDto RetornaDiretorPorId(int id)
        {
            Diretor diretor = _repository.Retorna(id);
            if( diretor != null ) return _mapper.Map<ReadDiretorDto>(diretor);
            return null;
        }

        public List<ReadDiretorDto> RetornaListaDeDiretores()
        {
            return _mapper.Map<List<ReadDiretorDto>>(_repository.RetornaLista());
        }
    }
}
