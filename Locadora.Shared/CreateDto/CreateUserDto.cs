using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared.CreateDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O campo Username é obrigatório!")]
        [Range(1, 20, ErrorMessage = "O Username deve conter no mínimo 1 e no máximo 20 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório!")]
        [Range(1, 20, ErrorMessage = "O Password deve conter no mínimo 1 e no máximo 20 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Role é obrigatório!")]
        [Range(1, 9, ErrorMessage = "Deve ser Manager ou Employee.")]
        public string Role { get; set; }
    }
}
