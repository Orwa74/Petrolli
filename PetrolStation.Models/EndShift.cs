using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PetrolStation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models
{
    public class EndShift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Notes { get; set; }

        [Required]
        [DisplayName("Liter Price")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public decimal TotalProce { get; set; }

        [Required]
        [Display(Name = "Pump")]
        public int PumpId { get; set; }

        [ValidateNever]
        public Pump? Pump { get; set; }

        [Required]
        public int PumpMeter { get; set; }

        [Required]
        public int PumpLastMeter { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee? Employee { get; set; }

        [Required]
        [Display(Name = "Shift")]
        public int ShiftId { get; set; }

        [ValidateNever]
        public Shift? Shift { get; set; }

        [Required]
        [Display(Name = "CashBox")]
        public int CashBoxId { get; set; }

        [ValidateNever]
        public CashBox? CashBox { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

    }
}
