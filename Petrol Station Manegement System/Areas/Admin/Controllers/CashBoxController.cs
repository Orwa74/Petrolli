using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Linq;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class CashBoxController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public CashBoxController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<CashBox> objCashBoxList = _unitOfWork.CashBox.GetAll();
            return View(objCashBoxList);
        }

        //GET
        public IActionResult Create()
        {
           
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CashBox obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CashBox.Add(obj);
                obj.Date = DateTime.Now;
                _unitOfWork.Save();
                TempData["success"] = "CashBox created successfully";
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
           
            var cashBoxFromDbFirst = _unitOfWork.CashBox.GetFirstOrDefault(u => u.Id == id);
            if (cashBoxFromDbFirst == null)
            {
                return NotFound();
            }
            return View(cashBoxFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CashBox.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CashBox.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CashBox deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
