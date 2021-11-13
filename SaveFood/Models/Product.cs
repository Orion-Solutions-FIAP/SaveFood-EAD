using System;
using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class Product
    {
        [Display(Name="Nome")]
        public string Name { get; set; }
        [Display(Name= "Data de validade"), DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Display(Name="Quantidade")]
        public int Amount { get; set; }
        [Display(Name="Armazenamento")]
        public int StorageId { get; set; }
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public Storage Storages { get; set; }
        public Category Categories { get; set; }
    }
}
