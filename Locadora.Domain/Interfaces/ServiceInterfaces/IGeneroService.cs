using FluentResults;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Domain.Interfaces.ServiceInterfaces
{
    public interface IGeneroService
    {
        void AdicionaGenero(CreateGeneroDto createDto);
        Result AtualizaGenero(int id, CreateGeneroDto createDto);
        Result DeletaGenero(int id);
        ReadGeneroDto RetornaGeneroPorId(int id);
        List<ReadGeneroDto> RetornaListaDeGeneros();
    }
}
