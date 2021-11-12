using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class User
    {
        [Display(Name="Nome")]
        public string Name { get; set; }
        
        [Display(Name="E-mail")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
