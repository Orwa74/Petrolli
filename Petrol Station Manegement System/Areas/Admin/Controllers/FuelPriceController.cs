using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;

using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class FuelPriceController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public FuelPriceController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            var fuelPrices = _unitOfWork.FuelPrice.GetAll(includeProperties: "FuelType");
            return View(fuelPrices);
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            FuelPriceVM FuelPriceVM = new()
            {
                FuelPrice = new(),
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0) 
            {
                //Create FuelPrice
                return View(FuelPriceVM);
            }
            else
            {
                //Update FuelPrice
                FuelPriceVM.FuelPrice = _unitOfWork.FuelPrice.GetFirstOrDefault(u => u.Id == id);
                return View(FuelPriceVM);
            }
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FuelPriceVM obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.FuelPrice.Id == 0)
                {
                    obj.FuelPrice.Date = DateTime.Now;
                    _unitOfWork.FuelPrice.Add(obj.FuelPrice);
                    TempData["success"] = "FuelPrice created successfully";
                }
                else
                {
                    obj.FuelPrice.Date = DateTime.Now;
                    _unitOfWork.FuelPrice.Update(obj.FuelPrice);
                    TempData["success"] = "FuelPrice updated successfully";
                }
                
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            obj.FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
            {
                Text = i.Fuel_Type,
                Value = i.Id.ToString()
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
            var FuelPriceFromDbFirst = _unitOfWork.FuelPrice.GetFirstOrDefault(u => u.Id == id,
                includeProperties:"FuelType");
            if (FuelPriceFromDbFirst == null)
            {
                return NotFound();
            }
            return View(FuelPriceFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.FuelPrice.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.FuelPrice.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "FuelPrice deleted successfully";
            return RedirectToAction("Index");

        }

        public IActionResult DashIndex()
        {
            var fuelPrices = _unitOfWork.FuelPrice.GetAll(includeProperties: "FuelType");
            return View(fuelPrices);
        }

        //GET
        public IActionResult DashEdit(int? id)
        {
            FuelPriceVM FuelPriceVM = new()
            {
                FuelPrice = new(),
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                })
            };

                FuelPriceVM.FuelPrice = _unitOfWork.FuelPrice.GetFirstOrDefault(u => u.Id == id);
                return View(FuelPriceVM);
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DashEdit(FuelPriceVM obj)
        {
            if (ModelState.IsValid)
            {

                obj.FuelPrice.Date = DateTime.Now;
                _unitOfWork.FuelPrice.Update(obj.FuelPrice);
                TempData["success"] = "FuelPrice updated successfully";
                _unitOfWork.Save();

                return RedirectToAction("DashIndex");
            }

            obj.FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
            {
                Text = i.Fuel_Type,
                Value = i.Id.ToString()
            });

            return View(obj);
        }

    }
}
