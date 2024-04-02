using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class User_login
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
