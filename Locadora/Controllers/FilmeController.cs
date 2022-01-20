﻿using FluentResults;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Shared;
using Locadora.Shared.ReadDto;
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

        [HttpPost]
        public IActionResult Adicionar(CreateFilmeDto createDto)
        {
            _service.AdicionaFilme(createDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult RetornaLista()
        {
            List<ReadFilmeComDiretorDto> listDto = _service.RetornaListaDeFilmes();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("nome/{nome}")]
        public IActionResult RetornaPorNome(string nome)
        {
            List<ReadFilmeComDiretorDto> listDto = _service.RetornaListaDeFilmesPorNome(nome);
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPorId(int id)
        {
            ReadFilmeComDiretorDto readDto = _service.RetornaFilmePorId(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPorId(int id, CreateFilmeDto createDto)
        {
            Result result = _service.AtualizaFilme(id, createDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPorId(int id)
        {
            Result result = _service.DeletaFilme(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
