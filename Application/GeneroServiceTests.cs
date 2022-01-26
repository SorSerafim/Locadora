using AutoMapper;
using Locadora.Application.Services;
using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class GeneroServiceTests
    {
        private readonly GeneroService _sut;
        private readonly Mock<IGeneroRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public GeneroServiceTests()
        {
            _repository = new Mock<IGeneroRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new GeneroService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void AdicionaGenero_DeveAdicionarUmGeneroAoBancoDeDados()
        {
            //Arrange

            CreateGeneroDto createDto = new CreateGeneroDto();
            createDto.Nome = "adiciona";

            Genero genero = new Genero();
            genero.Nome = "";
            genero.Id = 1;
            genero.Filmes = null;

            _mapper.Setup(x => x.Map<Genero>(createDto)).Returns(genero);

            //Act

            _sut.AdicionaGenero(createDto);

            //Assert

            _repository.Verify(x => x.Adiciona(genero), Times.Once());
        }

        [Fact]
        public void AtualizaGenero_DeveAtualizarUmGeneroNoBancoDeDados()
        {
            //Arrange

            CreateGeneroDto createDto = new CreateGeneroDto();
            createDto.Nome = "atualiza";

            Genero genero = new Genero();
            genero.Nome = "";
            genero.Id = 1;
            genero.Filmes = null;

            _mapper.Setup(x => x.Map<Genero>(createDto)).Returns(genero);

            _repository.Setup(x => x.Retorna(1)).Returns(genero);

            //Act

            var resultado = _sut.AtualizaGenero(1, createDto);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Atualiza(genero), Times.Once());
        }

        [Fact]
        public void AtualizaGenero_CasoDeRetornoNulo()
        {
            //Arrange

            CreateGeneroDto createDto = new CreateGeneroDto();
            createDto.Nome = "atualiza";

            Genero genero = new Genero();
            genero.Nome = "";
            genero.Id = 1;
            genero.Filmes = null;

            _mapper.Setup(x => x.Map<Genero>(createDto)).Returns(genero);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Genero);

            //Act

            var resultado = _sut.AtualizaGenero(1, createDto);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void DeletaGenero_DeveDeletarUmGeneroNoBancoDeDados()
        {
            //Arrange

            CreateGeneroDto createDto = new CreateGeneroDto();
            createDto.Nome = "deleta";

            Genero genero = new Genero();
            genero.Nome = "";
            genero.Id = 1;
            genero.Filmes = null;

            _mapper.Setup(x => x.Map<Genero>(createDto)).Returns(genero);

            _repository.Setup(x => x.Retorna(1)).Returns(genero);

            //Act

            var resultado = _sut.DeletaGenero(1);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Deleta(genero), Times.Once());
        }

        [Fact]
        public void DeletaGenero_CasoDeRetornoNulo()
        {
            //Arrange

            CreateGeneroDto createDto = new CreateGeneroDto();
            createDto.Nome = "deleta";

            Genero genero = new Genero();
            genero.Nome = "";
            genero.Id = 1;
            genero.Filmes = null;

            _mapper.Setup(x => x.Map<Genero>(createDto)).Returns(genero);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Genero);

            //Act

            var resultado = _sut.DeletaGenero(1);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void RetornaGeneroPorId_DeveRetornarUmReadGeneroDtoPeloId()
        {
            //Arrange

            Genero genero = new Genero();
            genero.Nome = "retornaPorId";
            genero.Id = 1;
            genero.Filmes = null;

            ReadGeneroDto readDto = new ReadGeneroDto();
            readDto.Nome = "";
            readDto.Id = 1;

            _mapper.Setup(x => x.Map<ReadGeneroDto>(genero)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(genero);

            //Act

            var resultado = _sut.RetornaGeneroPorId(1);

            //Assert

            Assert.Equal(readDto, resultado);

            _repository.Verify(x => x.Retorna(1), Times.Once());
        }

        [Fact]
        public void RetornaGeneroPorId_CasoDeRetornoNulo()
        {
            //Arrange

            Genero genero = new Genero();
            genero.Nome = "retornaPorId";
            genero.Id = 1;
            genero.Filmes = null;

            ReadGeneroDto readDto = new ReadGeneroDto();
            readDto.Nome = "";
            readDto.Id = 1;

            _mapper.Setup(x => x.Map<ReadGeneroDto>(genero)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Genero);

            //Act

            var resultado = _sut.RetornaGeneroPorId(1);

            //Assert

            Assert.Equal(null, resultado);
        }

        [Fact]
        public void RetornaListaDeGenero_DeveRetornarUmaListaDeGenero()
        {
            //Arrange

            Genero genero = new Genero();
            genero.Nome = "retornalista";
            genero.Id = 1;
            genero.Filmes = null;

            ReadGeneroDto readDto = new ReadGeneroDto();
            readDto.Nome = "";
            readDto.Id = 1;

            List<Genero> list = new List<Genero>();
            list.Add(genero);

            List<ReadGeneroDto> listDto = new List<ReadGeneroDto>();
            listDto.Add(readDto);

            _mapper.Setup(x => x.Map<List<ReadGeneroDto>>(list)).Returns(listDto);

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaListaDeGeneros();

            //Assert

            Assert.IsType<List<ReadGeneroDto>>(resultado);

            _repository.Verify(x => x.RetornaLista(), Times.Once());
        }
    }
}
