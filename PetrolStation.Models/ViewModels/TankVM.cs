using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetrolStation.Models.ViewModels
{
    public class TankVM
    {
        public Tank Tank { get; set; }

        // Properties for adding fuel
        [Display(Name = "Select Tank")]
        public int TankId { get; set; }

        [Display(Name = "Fuel Amount (in liters)")]
        public double FuelAmount { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TankList { get; set; }

    }
}
