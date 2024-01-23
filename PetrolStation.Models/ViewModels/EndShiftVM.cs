using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class EndShiftVM
    {
        public EndShift EndShift { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> PumpList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ShiftList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CashBoxList { get; set; }

    }
}
