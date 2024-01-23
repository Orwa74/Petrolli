using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Diagnostics;
using System.Linq;
using X.PagedList;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class FuelAdditionController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public FuelAdditionController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index(int? page,string sortOrder)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_aesc" : "";
            var FuelAdditions = _unitOfWork.FuelAddition.GetAll(includeProperties: "FuelType,Tank");

            switch (sortOrder)
            {
                case "date_aesc":
                    FuelAdditions = FuelAdditions.OrderBy(s => s.Date);
                    break;
                default:
                    FuelAdditions = FuelAdditions.OrderByDescending(s => s.Date);
                    break;
            }

            var paginatedEndShifts = FuelAdditions.ToPagedList(page ?? 1, 5);
            return View(paginatedEndShifts);
        }

        // GET
        public IActionResult Add()
        {
            var AdditionVM = new FuelAdditionVM
            {
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(ft => new SelectListItem
                {
                    Text = ft.Fuel_Type,
                    Value = ft.Id.ToString()
                }),
                TankList = _unitOfWork.Tank.GetAll().Select(t => new SelectListItem
                {
                    Text = t.TankName,
                    Value = t.Id.ToString()
                })
            };

            return View(AdditionVM);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FuelAdditionVM obj)
        {
            if (ModelState.IsValid)
            {
                var fuelAddition = obj.FuelAddition;

                // Update the tank's current quantity
                var tank = _unitOfWork.Tank.GetFirstOrDefault(t => t.Id == fuelAddition.TankId);
                if (tank != null)
                {
                    tank.Current_Quantity += fuelAddition.QuantityAdded;
                    _unitOfWork.Tank.Update(tank);

                   
                }

                obj.FuelAddition.Date = DateTime.Now;
                _unitOfWork.FuelAddition.Add(fuelAddition);
                if(tank.Current_Quantity <= tank.Capacity)
                {
                    _unitOfWork.Save();
                    TempData["success"] = "Fuel added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("AddFuelError", "The Fuel Amount Can't be more than the Tank Capacity.");
                }
               
            }

            obj.FuelTypeList = _unitOfWork.FuelType.GetAll().Select(ft => new SelectListItem
            {
                Text = ft.Fuel_Type,
                Value = ft.Id.ToString()
            });
            obj.TankList = _unitOfWork.Tank.GetAll().Select(t => new SelectListItem
                {
                    Text = t.TankName,
                    Value = t.Id.ToString()
                });
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var FuelAdditionFromDbFirst = _unitOfWork.FuelAddition.GetFirstOrDefault(u => u.Id == id,
            includeProperties: "FuelType,Tank");
            if (FuelAdditionFromDbFirst == null)
            {
                return NotFound();
            }
            return View(FuelAdditionFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.FuelAddition.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.FuelAddition.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
