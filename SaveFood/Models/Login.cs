using System.ComponentModel.DataAnnotations;

namespace SaveFood.Models
{
    public class Login
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
