using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetrolStation.Models
{
    public class FuelType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Fuel Type")]
        [MaxLength(50)]
        public string? Fuel_Type { get; set; }

        // Navigation property to FuelPrices
        public ICollection<FuelPrice>? FuelPrices { get; set; }

        // Navigation property to Crowding
        public Crowding? Crowding { get; set; }

        public Tank? Tank { get; set; }


    }
   
}
