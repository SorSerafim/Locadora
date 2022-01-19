using FluentResults;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiretorController : ControllerBase
    {
        private IDiretorService _service;

        public DiretorController(IDiretorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Adicionar(CreateDiretoresDto createDto)
        {
            _service.AdicionaDiretor(createDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult RetornaLista()
        {
            List<ReadDiretorDto> listDto = _service.RetornaListaDeDiretores();
            if(listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPorId(int id)
        {
            ReadDiretorDto readDto = _service.RetornaDiretorPorId(id);
            if(readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPorId(int id, CreateDiretoresDto createDto)
        {
            Result result = _service.AtualizaDiretor(id, createDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPorId(int id)
        {
            Result result = _service.DeletaDiretor(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
