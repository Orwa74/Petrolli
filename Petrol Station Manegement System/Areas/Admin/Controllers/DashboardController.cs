using Microsoft.AspNetCore.Mvc;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Xml.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfwork _unitOfWork;

        public DashboardController(ApplicationDbContext db, IUnitOfwork unitOfwork)
        {
            _db = db;
            _unitOfWork = unitOfwork;
        }
        public IActionResult Index()
        {
            var viewModel = new DashboardVM
            {
                FuelTypes = _unitOfWork.FuelType.GetAll().ToList(),
                FuelPrices = _unitOfWork.FuelPrice.GetAll(includeProperties: "FuelType").ToList(),
                Tanks = _unitOfWork.Tank.GetAll(includeProperties: "FuelType").ToList(),
                Crowdings = _unitOfWork.Crowding.GetAll().ToList(),
                CashBox = _unitOfWork.CashBox.GetAll().ToList(),
                EndShifts = _unitOfWork.EndShift.GetAll(includeProperties: "Shift,Employee,Pump").OrderByDescending(x => x.Date).ToList()

            };
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Login", "User");
            }

            return View(viewModel);
        }

        public IActionResult Settings()
        {
            return View ();
        }
    }
}
