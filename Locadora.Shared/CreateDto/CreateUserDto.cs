using System.ComponentModel.DataAnnotations;

namespace Locadora.Shared.CreateDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O campo Username é obrigatório!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Role é obrigatório!")]
        public string Role { get; set; }
    }
}
