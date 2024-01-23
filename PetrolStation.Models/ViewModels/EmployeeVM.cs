using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ShiftList { get; set; }
 
    }
}
