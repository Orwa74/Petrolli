using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class FuelTypeController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public FuelTypeController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<FuelType> objFuelList = _unitOfWork.FuelType.GetAll();
            return View(objFuelList);
        }

        //GET
        public IActionResult Create()
        {
           
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FuelType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FuelType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Fuel Type created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var FuelTypeFromDbFirst = _unitOfWork.FuelType.GetFirstOrDefault(u => u.Id == id);
            if (FuelTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(FuelTypeFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FuelType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FuelType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Fuel Type updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fuelTypeFromDbFirst = _unitOfWork.FuelType.GetFirstOrDefault(u => u.Id == id);
            if (fuelTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(fuelTypeFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.FuelType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.FuelType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Fuel Type deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
