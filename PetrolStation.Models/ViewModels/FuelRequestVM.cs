using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class FuelRequestVM
    {
        public FuelRequest FuelRequest { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> SupplierList { get; set; }
           
    }
}
