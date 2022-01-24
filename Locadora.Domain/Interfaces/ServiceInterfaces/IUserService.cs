using FluentResults;
using Locadora.Domain.Models;
using Locadora.Shared.CreateDto;
using Locadora.Shared.ReadDto;

namespace Locadora.Domain.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        void AdicionaUser(CreateUserDto createDto);
        Result AtualizaUser(int id, CreateUserDto createDto);
        Result DeletaUser(int id);
        ReadUserDto RetornaUserPorId(int id);
        User RetornaUserPorUsernameESenha(string username, string password);
        List<ReadUserDto> RetornaListaDeUsers();
    }
}
