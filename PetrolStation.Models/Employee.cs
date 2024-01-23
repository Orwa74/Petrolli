using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        
        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Shift")]
        public int ShiftId { get; set; }

        [ValidateNever]
        public Shift? Shift { get; set; }

        [Required]
        public int Salary { get; set; }

        [Display(Name = "Role")]
        [MaxLength(50)]
        public string? Role { get; set; }

        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

    }
}
