using FluentResults;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeService _service;

        public FilmeController(IFilmeService service)
        {
            _service = service;
        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Manager")]
        public IActionResult Adicionar(CreateFilmeDto createDto)
        {
            _service.AdicionaFilme(createDto);
            return Ok();
        }

        [HttpGet("ListaDeFilmes")]
        [Authorize(Roles = "Manager")]
        public IActionResult RetornaLista()
        {
            List<ReadFilmeComDiretorDto> listDto = _service.RetornaListaDeFilmes();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("nome/{nome}")]
        [Authorize(Roles = "Manager")]
        public IActionResult RetornaPorNome(string nome)
        {
            List<ReadFilmeComDiretorDto> listDto = _service.RetornaListaDeFilmesDeUmDiretor(nome);
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult RetornaPorId(int id)
        {
            ReadFilmeComDiretorDto readDto = _service.RetornaFilmePorId(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult AtualizaPorId(int id, CreateFilmeDto createDto)
        {
            Result result = _service.AtualizaFilme(id, createDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeletaPorId(int id)
        {
            Result result = _service.DeletaFilme(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
