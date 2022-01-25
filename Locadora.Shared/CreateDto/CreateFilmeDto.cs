using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Range(1, 50, ErrorMessage = "O nome do Filme de conter no mínimo 1 e no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório!")]
        [Range(1, 2022, ErrorMessage = "O ano do lançamento do filme deve ser no máximo o ano atual.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Duracao é obrigatório!")]
        [Range(1, 300, ErrorMessage = "A duração deve estar em minutos e dever ser no máximo 300.")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo DiretorId é obrigatório!")]
        [Range(1, 3, ErrorMessage = "O Filme de conter no mínimo 1 Diretor.")]
        public int DiretorId { get; set; }

        [Required(ErrorMessage = "O campo GeneroId é obrigatório!")]
        [Range(1, 50, ErrorMessage = "O Filme de conter no mínimo 1 Gênero.")]
        public int GeneroId { get; set; }
    }
}
