using Microsoft.AspNetCore.Mvc;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public SupplierController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<Supplier> objSupplierList = _unitOfWork.Supplier.GetAll();
            return View(objSupplierList);
        }

        //GET
        public IActionResult Create()
        {
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplier.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Supplier created successfully";
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
            var SupplierFromDbFirst = _unitOfWork.Supplier.GetFirstOrDefault(u => u.Id == id);
            if (SupplierFromDbFirst == null)
            {
                return NotFound();
            }
            return View(SupplierFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplier.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Supplier updated successfully";
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
            var SupplierFromDbFirst = _unitOfWork.Supplier.GetFirstOrDefault(u => u.Id == id);
            if (SupplierFromDbFirst == null)
            {
                return NotFound();
            }
            return View(SupplierFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Supplier.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Supplier.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Supplier deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
