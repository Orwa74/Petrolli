using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetrolStation.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Station Name")]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Location { get; set; }

        [Required]
        [MaxLength(100)]

        public string? Address { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

    }
}
