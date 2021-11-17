using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório"), Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório"), Display(Name = "Senha"), StringLength(50, MinimumLength = 8, ErrorMessage = "O campo Senha deve ter entre 8 a 50 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
