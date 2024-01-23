using Microsoft.AspNetCore.Mvc;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class StationController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public StationController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<Station> objStationList = _unitOfWork.Station.GetAll();
            return View(objStationList);
        }

        //GET
        public IActionResult Create()
        {
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Station obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Station.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Station information added successfully";
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
            var StationFromDbFirst = _unitOfWork.Station.GetFirstOrDefault(u => u.Id == id);
            if (StationFromDbFirst == null)
            {
                return NotFound();
            }
            return View(StationFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Station obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Station.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Station information updated successfully";
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
            var StationFromDbFirst = _unitOfWork.Station.GetFirstOrDefault(u => u.Id == id);
            if (StationFromDbFirst == null)
            {
                return NotFound();
            }
            return View(StationFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Station.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Station.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Station deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
