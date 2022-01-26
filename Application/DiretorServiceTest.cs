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
    public class DiretorServiceTest
    {
        private readonly DiretorService _sut;
        private readonly Mock<IDiretorRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public DiretorServiceTest()
        {
            _repository = new Mock<IDiretorRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new DiretorService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void AdicionaDiretor_DeveAdicionarUmDiretorAoBancoDeDados()
        {
            //Arrange

            CreateDiretoresDto createDto = new CreateDiretoresDto();
            createDto.Nome = "adiciona";

            Diretor diretor = new Diretor();
            diretor.Nome = "";
            diretor.Id = 1;
            diretor.Filmes = null;

            _mapper.Setup(x => x.Map<Diretor>(createDto)).Returns(diretor);

            //Act

            _sut.AdicionaDiretor(createDto);

            //Assert

            _repository.Verify(x => x.Adiciona(diretor), Times.Once());
        }

        [Fact]
        public void AtualizaDiretor_DeveAtualizarUmDiretorNoBancoDeDados()
        {
            //Arrange

            CreateDiretoresDto createDto = new CreateDiretoresDto();
            createDto.Nome = "atualiza";

            Diretor diretor = new Diretor();
            diretor.Nome = "";
            diretor.Id = 1;
            diretor.Filmes = null;

            _mapper.Setup(x => x.Map<Diretor>(createDto)).Returns(diretor);

            _repository.Setup(x => x.Retorna(1)).Returns(diretor);

            //Act

            var resultado = _sut.AtualizaDiretor(1, createDto);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Atualiza(diretor), Times.Once());
        }

        [Fact]
        public void AtualizaDiretor_CasoDeRetornoNulo()
        {
            //Arrange

            CreateDiretoresDto createDto = new CreateDiretoresDto();
            createDto.Nome = "atualiza";

            Diretor diretor = new Diretor();
            diretor.Nome = "";
            diretor.Id = 1;
            diretor.Filmes = null;

            _mapper.Setup(x => x.Map<Diretor>(createDto)).Returns(diretor);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Diretor);

            //Act

            var resultado = _sut.AtualizaDiretor(1, createDto);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void DeletaDiretor_DeveDeletarUmDiretorNoBancoDeDados()
        {
            //Arrange

            CreateDiretoresDto createDto = new CreateDiretoresDto();
            createDto.Nome = "atualiza";

            Diretor diretor = new Diretor();
            diretor.Nome = "";
            diretor.Id = 1;
            diretor.Filmes = null;

            _mapper.Setup(x => x.Map<Diretor>(createDto)).Returns(diretor);

            _repository.Setup(x => x.Retorna(1)).Returns(diretor);

            //Act

            var resultado = _sut.DeletaDiretor(1);

            //Assert

            Assert.True(resultado.IsSuccess);

            _repository.Verify(x => x.Deleta(diretor), Times.Once());
        }

        [Fact]
        public void DeletaDiretor_CasoDeRetornoNulo()
        {
            //Arrange

            CreateDiretoresDto createDto = new CreateDiretoresDto();
            createDto.Nome = "atualiza";

            Diretor diretor = new Diretor();
            diretor.Nome = "";
            diretor.Id = 1;
            diretor.Filmes = null;

            _mapper.Setup(x => x.Map<Diretor>(createDto)).Returns(diretor);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Diretor);

            //Act

            var resultado = _sut.DeletaDiretor(1);

            //Assert

            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public void RetornaDiretorPorId_DeveRetornarUmReadDiretorDtoPeloId()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Nome = "retornaPorId";
            diretor.Id = 1;
            diretor.Filmes = null;

            ReadDiretorDto readDto = new ReadDiretorDto();
            readDto.Nome = "";
            readDto.Id = 0;
            readDto.Filmes = null;

            _mapper.Setup(x => x.Map<ReadDiretorDto>(diretor)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(diretor);

            //Act

            var resultado = _sut.RetornaDiretorPorId(1);

            //Assert

            Assert.Equal(readDto, resultado);

            _repository.Verify(x => x.Retorna(1), Times.Once());
        }

        [Fact]
        public void RetornaDiretorPorId_CasoDeRetornoNulo()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Nome = "retornaPorId";
            diretor.Id = 1;
            diretor.Filmes = null;

            ReadDiretorDto readDto = new ReadDiretorDto();
            readDto.Nome = "";
            readDto.Id = 0;
            readDto.Filmes = null;

            _mapper.Setup(x => x.Map<ReadDiretorDto>(diretor)).Returns(readDto);

            _repository.Setup(x => x.Retorna(1)).Returns(null as Diretor);

            //Act

            var resultado = _sut.RetornaDiretorPorId(1);

            //Assert

            Assert.Equal(null, resultado);
        }

        [Fact]
        public void RetornaListaDeDiretores_DeveRetornarUmaListaDeDiretores()
        {
            //Arrange

            Diretor diretor = new Diretor();
            diretor.Nome = "retornalista";
            diretor.Id = 1;
            diretor.Filmes = null;

            ReadDiretorDto readDto = new ReadDiretorDto();
            readDto.Nome = "";
            readDto.Id = 0;
            readDto.Filmes = null;

            List<Diretor> list = new List<Diretor>();
            list.Add(diretor);

            List<ReadDiretorDto> listDto = new List<ReadDiretorDto>();
            listDto.Add(readDto);

            _mapper.Setup(x => x.Map<List<ReadDiretorDto>>(list)).Returns(listDto);

            _repository.Setup(x => x.RetornaLista()).Returns(list);

            //Act

            var resultado = _sut.RetornaListaDeDiretores();

            //Assert

            Assert.IsType<List<ReadDiretorDto>>(resultado);

            _repository.Verify(x => x.RetornaLista(), Times.Once());
        }
    }
}
