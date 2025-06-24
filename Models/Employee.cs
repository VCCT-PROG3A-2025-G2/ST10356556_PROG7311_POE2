using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
