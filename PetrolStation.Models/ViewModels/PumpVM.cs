using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class PumpVM
    {
        public Pump Pump { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TankList { get; set; }

        
        public PumpStatus SelectedStatus { get; set; }
        [ValidateNever]
        public List<SelectListItem> StatusOptions { get; set; }

    }
}
