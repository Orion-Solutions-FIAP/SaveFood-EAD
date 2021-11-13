using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class Login
    {
        [Display(Name ="E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
