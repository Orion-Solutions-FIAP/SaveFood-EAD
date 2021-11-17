using SaveFood.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveFood.Models
{
    [Table("T_GI_USER")]
    public class User
    {
        public User()
        {

        }

        public User(Login login)
        {
            Email = login.Email;
            Password = login.Password;
        }

        [Column("id_user")]
        public int Id { get; set; }

        [Column("nm_user")]
        [Required(ErrorMessage ="O campo Nome é obrigatório"), Display(Name = "Nome"), StringLength(50, MinimumLength = 5, ErrorMessage ="O campo Nome deve ter entre 5 a 50 caracteres")]

        public string Name { get; set; }

        [Column("ds_email")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório"), Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Column("ds_pass")]
        [Required(ErrorMessage = "O campo Senha é obrigatório"), Display(Name = "Senha"), StringLength(50,  MinimumLength = 8, ErrorMessage = "O campo Senha deve ter entre 8 a 50 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirme a senha"), Display(Name = "Confirme a senha"), StringLength(50, MinimumLength = 8, ErrorMessage = "O campo Confirme a senha deve ter entre 8 a 50 caracteres")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Opa! sua senha não parece ser igual ao que foi digitado anteriormente.")]
        public string ConfirmPassword { get; set; }

        [Column("ds_salt")]
        public string Salt { get; set; }

        public virtual ICollection<Storage> Storages { get; set; }

        public void GenerateSalt()
        {
            Salt = CryptographyHelper.GenerateSalt();
        }

        public void EncryptPassword()
        {
            Password = CryptographyHelper.EncryptPassword(Password, Salt);
        }
    }
}
