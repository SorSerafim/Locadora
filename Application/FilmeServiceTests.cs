using AutoMapper;
using Locadora.Application.Services;
using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests
{
    public class FilmeServiceTests
    {
        private readonly FilmeService _sut;
        private readonly Mock<IFilmeRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public FilmeServiceTests()
        {
            _repository = new Mock<IFilmeRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new FilmeService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void AdicionaFilme_DeveAdicionarUmFilmeAoBancoDeDados()
        {
            //Arrange

            CreateFilmeDto createDto = new CreateFilmeDto();
            createDto.Nome = "adiciona";
            createDto.Ano = 1999;
            createDto.Duracao = 60;
            createDto.DiretorId = 1;
            createDto.GeneroId = 1;

            Diretor diretor = new Diretor();
            diretor.Id = 1;
            diretor.Nome = "Diretor";

            Genero genero = new Genero();
            genero.Id = 1;
            genero.Nome = "Genero";

            Filme filme = new Filme();
            filme.Id = 1;
            filme.Nome = "";
            filme.Ano = 0;
            filme.Duracao = 0;
            filme.Diretor = diretor;
            filme.DiretorId = 0;
            filme.Genero = genero;
            filme.GeneroId = 0;

            _mapper.Setup(x => x.Map<Filme>(createDto)).Returns(filme);

            //Act

            _sut.AdicionaFilme(createDto);

            //Assert

            _repository.Verify(x => x.Adiciona(filme), Times.Once());
        }

        [Fact]
        public void AtualizaFilme_DeveAtualizarUmFilmeNoBancoDeDados()
        {
            //Arrange

            CreateFilmeDto createDto = new CreateFilmeDto();
            createDto.Nome = "adiciona";
            createDto.Ano = 1999;
            createDto.Duracao = 60;
            createDto.DiretorId = 1;
            createDto.GeneroId = 1;

            Diretor diretor = new Diretor();
            diretor.Id = 1;
            diretor.Nome = "Diretor";

            Genero genero = new Genero();
            genero.Id = 1;
            genero.Nome = "Genero";

            Filme filme = new Filme();
            filme.Id = 1;
            filme.Nome = "";
            filme.Ano = 0;
            filme.Duracao = 0;
            filme.Diretor = diretor;
            filme.DiretorId = 0;
            filme.Genero = genero;
            filme.GeneroId = 0;

            _repository.Setup(x => x.Retorna(1)).Returns(filme);

            //Act

            var resultado = _sut.AtualizaFilme(1, createDto);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Atualiza(filme), Times.Once());
        }

        [Fact]
        public void AtualizaFilme_CasoDeRetornoNulo()
        {
            //Arrange

            CreateFilmeDto createDto = new CreateFilmeDto();
            createDto.Nome = "adiciona";
            createDto.Ano = 1999;
            createDto.Duracao = 60;
            createDto.DiretorId = 1;
            createDto.GeneroId = 1;

            Filme genero = new Filme();

            _repository.Setup(x => x.Retorna(1)).Returns(null as Filme);

            //Act

            var resultado = _sut.AtualizaFilme(1, createDto);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void DeletaFilme_DeveDeletarUmFilmeNoBancoDeDados()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Id = 1;
            diretor.Nome = "Diretor";

            Genero genero = new Genero();
            genero.Id = 1;
            genero.Nome = "Genero";

            Filme filme = new Filme();
            filme.Id = 1;
            filme.Nome = "";
            filme.Ano = 0;
            filme.Duracao = 0;
            filme.Diretor = diretor;
            filme.DiretorId = 0;
            filme.Genero = genero;
            filme.GeneroId = 0;

            _repository.Setup(x => x.Retorna(1)).Returns(filme);

            //Act

            var resultado = _sut.DeletaFilme(1);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Deleta(filme), Times.Once());
        }

        [Fact]
        public void DeletaFilme_CasoDeRetornoNulo()
        {
            //Arrange

            Filme filme = new Filme();

            _repository.Setup(x => x.Retorna(1)).Returns(null as Filme);

            //Act

            var resultado = _sut.DeletaFilme(1);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void RetornaFilmePorId_DeveRetornarUmReadFilmeDtoPeloId()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Id = 1;
            diretor.Nome = "Diretor";

            Genero genero = new Genero();
            genero.Id = 1;
            genero.Nome = "Genero";

            Filme filme = new Filme();
            filme.Id = 1;
            filme.Nome = "";
            filme.Ano = 0;
            filme.Duracao = 0;
            filme.Diretor = diretor;
            filme.DiretorId = 0;
            filme.Genero = genero;
            filme.GeneroId = 0;

            ReadFilmeComDiretorDto readDto = new ReadFilmeComDiretorDto();
            readDto.Nome = "";
            readDto.Ano = 0;
            readDto.Duracao = 0;
            readDto.Diretor = "Diretor";
            readDto.Genero = "Genero";

            _mapper.Setup(x => x.Map<ReadFilmeComDiretorDto>(filme)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(filme);

            //Act

            var resultado = _sut.RetornaFilmePorId(1);

            //Assert

            Assert.Equal(readDto, resultado);

            _repository.Verify(x => x.Retorna(1), Times.Once());
        }

        [Fact]
        public void RetornaFilmePorId_CasoDeRetornoNulo()
        {
            //Arrange

            Filme filme = new Filme();

            _repository.Setup(x => x.Retorna(1)).Returns(null as Filme);

            //Act

            var resultado = _sut.RetornaFilmePorId(1);

            //Assert

            Assert.Equal(null, resultado);
        }

        [Fact]
        public void RetornaListaDeFilme_DeveRetornarUmaListaDeFilme()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Id = 1;
            diretor.Nome = "Diretor";

            Genero genero = new Genero();
            genero.Id = 1;
            genero.Nome = "Genero";

            Filme filme = new Filme();
            filme.Id = 1;
            filme.Nome = "";
            filme.Ano = 0;
            filme.Duracao = 0;
            filme.Diretor = diretor;
            filme.DiretorId = 0;
            filme.Genero = genero;
            filme.GeneroId = 0;

            ReadFilmeComDiretorDto readDto = new ReadFilmeComDiretorDto();
            readDto.Nome = "";
            readDto.Ano = 0;
            readDto.Duracao = 0;
            readDto.Diretor = "Diretor";
            readDto.Genero = "Genero";

            List<Filme> list = new List<Filme>();
            list.Add(filme);

            List<ReadFilmeComDiretorDto> listDto = new List<ReadFilmeComDiretorDto>();
            listDto.Add(readDto);

            _mapper.Setup(x => x.Map<List<ReadFilmeComDiretorDto>>(list)).Returns(listDto);

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaListaDeFilmes();

            //Assert

            Assert.IsType<List<ReadFilmeComDiretorDto>>(resultado);

            _repository.Verify(x => x.RetornaLista(), Times.Once());
        }
    }
}
