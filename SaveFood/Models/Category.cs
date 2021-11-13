using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class Category
    {
        [Display(Name="Nome")]
        public string Name { get; set; }
    }
}
