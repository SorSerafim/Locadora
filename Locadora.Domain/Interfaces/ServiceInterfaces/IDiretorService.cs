using FluentResults;
using Locadora.Shared;
using Locadora.Shared.ReadDto;

namespace Locadora.Domain.Interfaces.ServiceInterfaces
{
    public interface IDiretorService
    {
        void AdicionaDiretor(CreateDiretoresDto createDto);
        Result AtualizaDiretor(int id, CreateDiretoresDto createDto);
        Result DeletaDiretor(int id);
        ReadDiretorDto RetornaDiretorPorId(int id);
        List<ReadDiretorDto> RetornaListaDeDiretores();
    }
}
