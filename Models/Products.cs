using System;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int FarmerId { get; set; }
    }
}
