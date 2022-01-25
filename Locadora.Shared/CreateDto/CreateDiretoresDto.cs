using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateDiretoresDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
