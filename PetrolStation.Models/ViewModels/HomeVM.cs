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
    public class HomeVM
    {
        public List<FuelType> FuelTypes { get; set; }
        public List<FuelPrice> FuelPrices { get; set; }
        public List<Tank> Tanks { get; set; }
        public List<Crowding> Crowdings { get; set; }
        public List<Station> Stations { get; set; }

    }
}
