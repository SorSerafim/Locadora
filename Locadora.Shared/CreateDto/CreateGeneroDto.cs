using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateGeneroDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
