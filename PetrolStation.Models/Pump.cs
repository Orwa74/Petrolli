using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class Pump
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pump Code")]
        [MaxLength(50)]
        public string? PumpCode{ get; set; }

        [Display(Name = "Current Meter")]
        public double CurrerntMeter { get; set; }

        [Required]
        public PumpStatus Status { get; set; }

        [Display(Name = "Last Updated")]
        [DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Tank")]
        public int TankId { get; set; }

        [ValidateNever]
        public Tank? Tank { get; set; }

        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        [ValidateNever]
        public FuelType? FuelType { get; set; }

       
    }

    public enum PumpStatus
    {
        Active,
        Maintenance,
        [Display(Name ="Out Of Order")]
        OutOfOrder
    }
}
