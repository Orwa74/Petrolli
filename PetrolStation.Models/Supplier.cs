using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string? Email { get; set; }
        
        [Required]
        [Phone]
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

    }
}
