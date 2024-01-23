using Microsoft.AspNetCore.Mvc;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public ShiftController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<Shift> objShiftList = _unitOfWork.Shift.GetAll();
            return View(objShiftList);
        }

        //GET
        public IActionResult Create()
        {
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shift obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Shift.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shift created successfully";
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
            var ShiftFromDbFirst = _unitOfWork.Shift.GetFirstOrDefault(u => u.Id == id);
            if (ShiftFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ShiftFromDbFirst);  

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shift obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Shift.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shift updated successfully";
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
            var ShiftFromDbFirst = _unitOfWork.Shift.GetFirstOrDefault(u => u.Id == id);
            if (ShiftFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ShiftFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Shift.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Shift.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Shift deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
