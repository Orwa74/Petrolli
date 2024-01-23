using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Models.ViewModels
{
    public class CrowdingVM
    {
        public Crowding Crowding { get; set; }

        
        public CrowdingLevel SelectedLevel { get; set; }
        [ValidateNever]
        public List<SelectListItem> CrowdingOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }

    }
}
