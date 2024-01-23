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
    public class PumpController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public PumpController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            var Pumps = _unitOfWork.Pump.GetAll(includeProperties: "Tank,FuelType");
            return View(Pumps);
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            PumpVM PumpVM = new()
            {
                Pump = new(),
                TankList = _unitOfWork.Tank.GetAll().Select(i => new SelectListItem
                {
                    Text = i.TankName,
                    Value = i.Id.ToString()
                }),
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                }),
                
                StatusOptions = Enum.GetValues(typeof(PumpStatus)).Cast<PumpStatus>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                   Value = ((int)s).ToString()
                }).ToList()
            };

            if (id == null || id == 0) 
            {
                //Create 
                return View(PumpVM);
            }
            else
            {
                //Update 
                PumpVM.Pump = _unitOfWork.Pump.GetFirstOrDefault(u => u.Id == id);
                return View(PumpVM);
            }
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PumpVM obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Pump.Id == 0)
                {
                    _unitOfWork.Pump.Add(obj.Pump);
                    TempData["success"] = "Pump created successfully";
                }
                else
                {
                    _unitOfWork.Pump.Update(obj.Pump);
                    TempData["success"] = "Pump updated successfully";
                }
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            obj.TankList = _unitOfWork.Tank.GetAll().Select(i => new SelectListItem
            {
                Text = i.TankName,
                Value = i.Id.ToString()
            });
            obj.FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
            {
                Text = i.Fuel_Type,
                Value = i.Id.ToString()
            });

            obj.StatusOptions = Enum.GetValues(typeof(PumpStatus)).Cast<PumpStatus>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                }).ToList();
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var PumpFromDbFirst = _unitOfWork.Pump.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "FuelType,Tank");
            if (PumpFromDbFirst == null)
            {
                return NotFound();
            }
            return View(PumpFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Pump.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Pump.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Pump deleted successfully";
            return RedirectToAction("Index");

        }

        

    }
}
