using FluentResults;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGeneroService _service;

        public GeneroController(IGeneroService service)
        {
            _service = service;
        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(CreateGeneroDto createDto)
        {
            _service.AdicionaGenero(createDto);
            return Ok();
        }

        [HttpGet("ListaDeGêneros")]
        public IActionResult RetornaLista()
        {
            List<ReadGeneroDto> listDto = _service.RetornaListaDeGeneros();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPorId(int id)
        {
            ReadGeneroDto readDto = _service.RetornaGeneroPorId(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPorId(int id, CreateGeneroDto createDto)
        {
            Result result = _service.AtualizaGenero(id, createDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPorId(int id)
        {
            Result result = _service.DeletaGenero(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
