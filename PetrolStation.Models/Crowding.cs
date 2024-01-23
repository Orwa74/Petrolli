using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Crowding
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CrowdingLevel Level { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType? FuelType { get; set; }
    }


    public enum CrowdingLevel
    {
        Low,
        Medium,
        High
    }
}
