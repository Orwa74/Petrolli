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
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Display(Name ="User Name")]
        public string? UserName { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength (50)]
        public string? Email { get; set; }
        
        
 
        public byte[] PasswordHash{ get; set; }

        public byte[] PasswordSalt { get; set; }

        [NotMapped]
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}
