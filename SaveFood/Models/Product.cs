using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveFood.Models
{
    [Table("T_GI_PRODUCT")]
    public class Product
    {
        [HiddenInput]
        [Column("id_product")]
        public int Id { get; set; }

        [HiddenInput]
        [Column("id_user")]
        public int UserId { get; set; }

        [HiddenInput]
        [Column("id_status")]
        public Status Status { get; set; } = Status.Enabled;

        [Column("id_place")]
        [Required(ErrorMessage = "Selecione um armazenamento"), Display(Name = "Armazenamento")]
        public int? StorageId { get; set; }

        [Column("id_category")]
        [Required(ErrorMessage = "Selecione uma categoria"), Display(Name = "Categoria")]
        public int? CategoryId { get; set; }

        [Column("nm_product")]
        [Required(ErrorMessage = "O campo Nome é obrigatório"), Display(Name = "Nome"), StringLength(60, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter entre 2 a 40 caracteres")]
        public string Name { get; set; }
        
        [Column("dt_expiration")]
        [Required(ErrorMessage = "O campo Data de validade é obrigatório"), Display(Name = "Data de validade"), DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        
        [Column("nr_quantity")]
        [Required(ErrorMessage = "O campo Quantidade é obrigatório"), Display(Name = "Quantidade"), Range(1,100, ErrorMessage ="Quantidade deve ser entre 1 a 100")]
        public int? Amount { get; set; }

        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Ativo")]
        Enabled = 1,

        [Display(Name = "Vencido")]
        Expired = 2
    }
}
