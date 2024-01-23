using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class PaymentVM
    {
        public Payment Payment { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CashBoxList { get; set; }

        public PaymentType SelectedType { get; set; }
        [ValidateNever]
        public List<SelectListItem> TypesOptions { get; set; }

    }
}
