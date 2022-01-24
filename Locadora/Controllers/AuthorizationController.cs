using Locadora.Common;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Locadora.Service;
using Locadora.Shared.CreateDto;
using Locadora.Shared.ReadDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IUserService _service;
        private Token _token;

        public AuthorizationController(IUserService service, Token token)
        {
            _service = service;
            _token = token;
        }

        [HttpPost("Cadastro")]
        public IActionResult Adicionar(CreateUserDto createDto)
        {
            createDto.Password = CommonMethods.ConvertToEncrypt(createDto.Password);
            _service.AdicionaUser(createDto);
            return Ok();
        }

        [HttpPost("Autenticar")]
        [AllowAnonymous]
        public string GetAutenticar(AuthorizeDto readDto)
        {
            return _token.GenerateToken(_service.RetornaUserPorUsernameESenha(readDto.username, CommonMethods.ConvertToEncrypt(readDto.password)));
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPorId(int id)
        {
            ReadUserDto readDto = _service.RetornaUserPorId(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpGet("ListaDeUsusários")]
        public IActionResult RetornaLista()
        {
            List<ReadUserDto> listDto = _service.RetornaListaDeUsers();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }
    }
}
