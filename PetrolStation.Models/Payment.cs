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
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee? Employee { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "The Price")]
        public decimal ThePrice { get; set; }

        [Required]
        [Display(Name = "CashBox")]
        public int CashBoxId { get; set; }

        [ValidateNever]
        public CashBox? CashBox { get; set; }

        

    }
    public enum PaymentType
    {
        Salary,
        Bills,
        Expenses,
        [Display(Name = "Fuel Purchase Invoice")]
        FuelPurchaseInvoice,
        Others
    }
}
