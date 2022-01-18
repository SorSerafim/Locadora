using FluentResults;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Domain.Interfaces.ServiceInterfaces
{
    public interface IFilmeService
    {
        void AdicionaFilme(CreateFilmeDto createDto);
        Result AtualizaFilme(int id, CreateFilmeDto createDto);
        Result DeletaFilme(int id);
        ReadFilmeDto RetornaFilmePorId(int id);
        List<ReadFilmeDto> RetornaListaDeFilmes();
    }
}
