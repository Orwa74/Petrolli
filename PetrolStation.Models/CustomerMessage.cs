using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class CustomerMessage
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
        [MaxLength(255)]
        public string? Message { get; set; }

        [Required]
        public DateTime SendTime { get; set; }
    }
}
