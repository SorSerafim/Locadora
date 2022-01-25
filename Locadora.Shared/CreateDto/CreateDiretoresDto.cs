using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateDiretoresDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Range(1, 50, ErrorMessage = "O nome do diretor de conter no mínimo 1 e no máximo 50 caracteres.")]
        public string Nome { get; set; }
    }
}
