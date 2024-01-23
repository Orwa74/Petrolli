using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Diagnostics;

namespace Petrol_Station_Manegement_System.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfwork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IUnitOfwork unitOfWork, ApplicationDbContext context)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            var fuelData = _context.FuelTypes
                 .Include(fuelType => fuelType.FuelPrices)
                 .Include(fuelType => fuelType.Crowding)
                 .Include(fuelType => fuelType.Tank)
                 .ToList();

           
            return View(fuelData);
        }


        public IActionResult AboutUs()
        {
            var station = _context.Stations.FirstOrDefault(); 
            return View(station);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}