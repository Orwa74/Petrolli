using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class FuelRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType? FuelType { get; set; }

        [Required]
        [Display(Name = "Fuel Amount")]
        [MaxLength(50)]
        public string? Amount { get; set; }


        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [ValidateNever]
        public Supplier? Supplier { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Notes { get; set; }

    }
}
