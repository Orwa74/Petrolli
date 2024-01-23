using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetrolStation.Models
{
    public class FuelPrice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Purrechasing Price")]
        public double PurrechasingPrice { get; set; }

        [Required]
        [DisplayName("Seling Price")]
        public double SelingPrice { get; set; }

        [Required]
        [Display(Name = "Last Change")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType? FuelType { get; set; }

    }
}
