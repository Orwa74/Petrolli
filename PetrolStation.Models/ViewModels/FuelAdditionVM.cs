using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class FuelAdditionVM
    {
        public FuelAddition FuelAddition { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TankList { get; set; }

    }
}
