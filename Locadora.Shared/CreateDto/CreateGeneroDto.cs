using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateGeneroDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Range(1, 50, ErrorMessage = "O nome do Gênero de conter no mínimo 1 e no máximo 50 caracteres.")]
        public string Nome { get; set; }
    }
}
