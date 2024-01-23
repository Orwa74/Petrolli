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
    public class CrowdingController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public CrowdingController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            var Crowd = _unitOfWork.Crowding.GetAll(includeProperties: "FuelType");
            return View(Crowd);
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            CrowdingVM CrowdingVM = new()
            {
                Crowding = new(),

                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                }),

                CrowdingOptions = Enum.GetValues(typeof(CrowdingLevel)).Cast<CrowdingLevel>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                //Create 
                return View(CrowdingVM);
            }
            else
            {
                //Update 
                CrowdingVM.Crowding = _unitOfWork.Crowding.GetFirstOrDefault(u => u.Id == id);
                return View(CrowdingVM);
            }



        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CrowdingVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Crowding.Id == 0)
                {
                    obj.Crowding.LastUpdate = DateTime.Now;
                    _unitOfWork.Crowding.Add(obj.Crowding);
                }
                else
                {
                    obj.Crowding.LastUpdate = DateTime.Now;
                    _unitOfWork.Crowding.Update(obj.Crowding);
                    TempData["success"] = "Crowding Level updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult DashIndex()
        {
            var Crowd = _unitOfWork.Crowding.GetAll(includeProperties: "FuelType");
            return View(Crowd);
        }


        //GET
        public IActionResult DashEdit(int? id)
        {
            CrowdingVM CrowdingVM = new()
            {
                Crowding = new(),

                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Fuel_Type,
                    Value = i.Id.ToString()
                }),

                CrowdingOptions = Enum.GetValues(typeof(CrowdingLevel)).Cast<CrowdingLevel>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                }).ToList()
            };

            CrowdingVM.Crowding = _unitOfWork.Crowding.GetFirstOrDefault(u => u.Id == id);
            return View(CrowdingVM);
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DashEdit(CrowdingVM obj)
        {
            if (ModelState.IsValid)
            {
                obj.Crowding.LastUpdate = DateTime.Now;
                _unitOfWork.Crowding.Update(obj.Crowding);
                TempData["success"] = "Crowding Level updated successfully";
                _unitOfWork.Save();

                return RedirectToAction("DashIndex");
            }

            return View(obj);
        }
    }
}
