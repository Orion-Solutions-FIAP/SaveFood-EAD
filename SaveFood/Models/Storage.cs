using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveFood.Models
{
    [Table("T_GI_PLACE")]
    public class Storage
    {
        [Column("id_place")]
        public int Id { get; set; }

        [Column("id_user")]
        public int UserId { get; set; }

        [Column("nm_place")]
        [Required(ErrorMessage ="O campo Nome é obrigatório"), Display(Name = "Nome"), StringLength(40, MinimumLength = 2, ErrorMessage = "O campo Senha deve ter entre 2 a 40 caracteres")]
        public string Name { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
