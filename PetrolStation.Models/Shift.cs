using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Shift Name")]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

    }
}
