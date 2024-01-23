using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Tank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Capacity { get; set; }

        [Display(Name = "Current Quantity")]
        public double Current_Quantity { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType FuelType { get; set; }
    }
}
