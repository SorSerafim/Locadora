using AutoMapper;
using FluentResults;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Domain.Models;
using Locadora.Shared.CreateDto;
using Locadora.Shared.ReadDto;

namespace Locadora.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AdicionaUser(CreateUserDto createDto)
        {
            _repository.Adiciona(_mapper.Map<User>(createDto));
        }

        public Result AtualizaUser(int id, CreateUserDto createDto)
        {
            User user = _repository.Retorna(id);
            if(user != null)
            {
                user.Username = createDto.Username;
                user.Password = createDto.Password;
                user.Role = createDto.Role;
                _repository.Atualiza(user);
                return Result.Ok();
            }
            return Result.Fail("Usuário não encontrado!");
        }

        public Result DeletaUser(int id)
        {
            User user = _repository.Retorna(id);
            if(user != null)
            {
                _repository.Deleta(user);
                return Result.Ok();
            }
            return Result.Fail("Usuário não encontrado!");
        }

        public ReadUserDto RetornaUserPorId(int id)
        {
            User user = _repository.Retorna(id);
            if( user != null ) return _mapper.Map<ReadUserDto>(user);
            return null;
        }

        public List<ReadUserDto> RetornaListaUsers()
        {
            return _mapper.Map<List<ReadUserDto>>(_repository.RetornaLista());
        }
    }
}
