using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetrolStation.Models
{
    public class CashBox
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [DisplayName("Current Amount")]
        public decimal CurrentAmount { get; set; }

        [Required]
        [Display(Name = "Changing Time")]
        public DateTime Date { get; set; }

       

    }
}
