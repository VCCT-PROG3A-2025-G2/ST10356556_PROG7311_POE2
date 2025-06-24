using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string Contact { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string? Password { get; set; }
    }
}
