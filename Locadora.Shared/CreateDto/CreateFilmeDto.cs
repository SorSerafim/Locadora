using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório!")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Duracao é obrigatório!")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo DiretorId é obrigatório!")]
        public int DiretorId { get; set; }

        [Required(ErrorMessage = "O campo GeneroId é obrigatório!")]
        public int GeneroId { get; set; }
    }
}
