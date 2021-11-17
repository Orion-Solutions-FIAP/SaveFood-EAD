using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveFood.Models
{
    [Table("T_GI_CATEGORY")]
    public class Category
    {
        [Column("id_category")]
        public int Id { get; set; }

        [Column("id_user")]
        public int UserId { get; set; }

        [Column("nm_category")]
        [Required(ErrorMessage = "O campo Nome é obrigatório"), Display(Name = "Nome"), StringLength(40, MinimumLength = 2, ErrorMessage = "O campo Senha deve ter entre 2 a 40 caracteres")]
        public string Name { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
