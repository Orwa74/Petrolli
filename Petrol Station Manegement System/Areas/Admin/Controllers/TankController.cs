using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class TankController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public TankController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            var tanks = _unitOfWork.Tank.GetAll(includeProperties: "FuelType");
            return View(tanks);
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            TankVM tankVM = new()
            {
                Tank = new(),
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0) 
            {
                //Create Tank
                return View(tankVM);
            }
            else
            {
                //Update Tank
                tankVM.Tank = _unitOfWork.Tank.GetFirstOrDefault(u => u.Id == id);
                return View(tankVM);
            }
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TankVM obj)
        {
            if (ModelState.IsValid)
            {

                if(obj.Tank.Id == 0)
                {
                    _unitOfWork.Tank.Add(obj.Tank);
                    TempData["success"] = "Tank created successfully";
                }
                else
                {
                    _unitOfWork.Tank.Update(obj.Tank);
                    TempData["success"] = "Tank updated successfully";
                }
                if (obj.Tank.Current_Quantity <= obj.Tank.Capacity)
                {
                    _unitOfWork.Save();
                    TempData["success"] = "Tank Updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("AddFuelError", "The Fuel Amount Can't be more than the Tank Capacity.");
                }
                
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
            var TankFromDbFirst = _unitOfWork.Tank.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "FuelType");
            if (TankFromDbFirst == null)
            {
                return NotFound();
            }
            return View(TankFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Tank.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Tank.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Tank deleted successfully";
            return RedirectToAction("Index");

        }

       
    }
}
