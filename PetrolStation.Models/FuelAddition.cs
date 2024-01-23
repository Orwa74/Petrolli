using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetrolStation.Models
{
    public class FuelAddition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Purchasing Price")]
        public double PurchasingFuelPrice { get; set; }

        [Required]
        [DisplayName("Fuel Amount")]
        public double QuantityAdded { get; set; }

        [Required]
        [Display(Name = "Adding Time")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType? FuelType { get; set; }

        [Required]
        [Display(Name = "Tank Name")]
        public int TankId { get; set; }

        [ValidateNever]
        public Tank? Tank { get; set; }

    }
}
