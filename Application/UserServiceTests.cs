using AutoMapper;
using Locadora.Application.Services;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Models;
using Locadora.Shared.CreateDto;
using Locadora.Shared.ReadDto;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public UserServiceTests()
        {
            _repository = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new UserService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void AdicionaUser_DeveAdicionarUmUserAoBancoDeDados()
        {
            //Arrange

            CreateUserDto createDto = new CreateUserDto();
            createDto.Username = "adiciona";
            createDto.Password = "senha";
            createDto.Role = "Manager";

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            _mapper.Setup(x => x.Map<User>(createDto)).Returns(user);

            //Act

            _sut.AdicionaUser(createDto);

            //Assert

            _repository.Verify(x => x.Adiciona(user), Times.Once());
        }

        [Fact]
        public void AtualizaUser_DeveAtualizarUmUserNoBancoDeDados()
        {
            //Arrange

            CreateUserDto createDto = new CreateUserDto();
            createDto.Username = "atualiza";
            createDto.Password = "senha";
            createDto.Role = "Manager";

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            _mapper.Setup(x => x.Map<User>(createDto)).Returns(user);

            _repository.Setup(x => x.Retorna(1)).Returns(user);

            //Act

            var resultado = _sut.AtualizaUser(1, createDto);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Atualiza(user), Times.Once());
        }

        [Fact]
        public void AtualizaUser_CasoDeRetornoNulo()
        {
            //Arrange

            CreateUserDto createDto = new CreateUserDto();
            createDto.Username = "atualiza";
            createDto.Password = "senha";
            createDto.Role = "Manager";

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            _mapper.Setup(x => x.Map<User>(createDto)).Returns(user);

            _repository.Setup(x => x.Retorna(1)).Returns(null as User);

            //Act

            var resultado = _sut.AtualizaUser(1, createDto);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void DeletaUser_DeveDeletarUmUserNoBancoDeDados()
        {
            //Arrange

            CreateUserDto createDto = new CreateUserDto();
            createDto.Username = "deleta";
            createDto.Password = "senha";
            createDto.Role = "Manager";

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            _mapper.Setup(x => x.Map<User>(createDto)).Returns(user);

            _repository.Setup(x => x.Retorna(1)).Returns(user);

            //Act

            var resultado = _sut.DeletaUser(1);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Deleta(user), Times.Once());
        }

        [Fact]
        public void DeletaUser_CasoDeRetornoNulo()
        {
            //Arrange

            CreateUserDto createDto = new CreateUserDto();
            createDto.Username = "deleta";
            createDto.Password = "senha";
            createDto.Role = "Manager";

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            _mapper.Setup(x => x.Map<User>(createDto)).Returns(user);

            _repository.Setup(x => x.Retorna(1)).Returns(null as User);

            //Act

            var resultado = _sut.DeletaUser(1);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void RetornaUserPorId_DeveRetornarUmReadUserDtoPeloId()
        {
            //Arrange

            User user = new User();
            user.Id = 1;
            user.Username = "retorna";
            user.Password = "senha";
            user.Role = "Manager";

            ReadUserDto readDto = new ReadUserDto();
            readDto.Id = 1;
            readDto.Username = "";
            readDto.Role = "";

            _mapper.Setup(x => x.Map<ReadUserDto>(user)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(user);

            //Act

            var resultado = _sut.RetornaUserPorId(1);

            //Assert

            Assert.Equal(readDto, resultado);

            _repository.Verify(x => x.Retorna(1), Times.Once());
        }

        [Fact]
        public void RetornaUserPorId_CasoDeRetornoNulo()
        {
            //Arrange

            User user = new User();
            user.Id = 1;
            user.Username = "retorna";
            user.Password = "senha";
            user.Role = "Manager";

            ReadUserDto readDto = new ReadUserDto();
            readDto.Id = 1;
            readDto.Username = "";
            readDto.Role = "";

            _mapper.Setup(x => x.Map<ReadUserDto>(user)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(null as User);

            //Act

            var resultado = _sut.RetornaUserPorId(1);

            //Assert

            Assert.Equal(null, resultado);
        }

        [Fact]
        public void RetornaUserPorUsernameESenha_DeveRetornarUmReadUserDtoPorUsernameESenha()
        {
            //Arrange

            string username = "retornaPorUser";
            string password = "senha";

            User user = new User();
            user.Id = 1;
            user.Username = "retornaPorUser";
            user.Password = "senha";
            user.Role = "Manager";

            ReadUserDto readDto = new ReadUserDto();
            readDto.Id = 1;
            readDto.Username = "";
            readDto.Role = "";

            _mapper.Setup(x => x.Map<ReadUserDto>(user)).Returns(readDto);

            List<User> list = new List<User>();
            list.Add(user);

            List<ReadUserDto> listDto = new List<ReadUserDto>();
            listDto.Add(readDto);

            _mapper.Setup(x => x.Map<List<ReadUserDto>>(list)).Returns(listDto);

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaUserPorUsernameESenha(user.Username, user.Password);

            //Assert

            Assert.Equal(readDto, resultado);

            _repository.Verify(x => x.RetornaLista(), Times.Once());
        }

        [Fact]
        public void RetornaUserPorUsernameESenha_CasoDeRetornoNulo()
        {
            //Arrange

            string username = "retornaPorUser";
            string password = "senha";

            User user = new User();
            user.Id = 1;
            user.Username = "retornaPorUser";
            user.Password = "senha";
            user.Role = "Manager";

            ReadUserDto readDto = new ReadUserDto();
            readDto.Id = 1;
            readDto.Username = "";
            readDto.Role = "";

            _mapper.Setup(x => x.Map<ReadUserDto>(user)).Returns(readDto);

            List<User> list = new List<User>();           

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaUserPorUsernameESenha(username, password);

            //Assert

            Assert.Equal(null, resultado);
        }

        [Fact]
        public void RetornaListaDeUser_DeveRetornarUmaListaDeUser()
        {
            //Arrange

            User user = new User();
            user.Id = 1;
            user.Username = "";
            user.Password = "";
            user.Role = "";

            ReadUserDto readDto = new ReadUserDto();
            readDto.Id = 1;
            readDto.Username = "retornalista";
            readDto.Role = "Manager";

            List<User> list = new List<User>();
            list.Add(user);

            List<ReadUserDto> listDto = new List<ReadUserDto>();
            listDto.Add(readDto);

            _mapper.Setup(x => x.Map<List<ReadUserDto>>(list)).Returns(listDto);

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaListaDeUsers();

            //Assert

            Assert.IsType<List<ReadUserDto>>(resultado);

            _repository.Verify(x => x.RetornaLista(), Times.Once());
        }
    }
}
