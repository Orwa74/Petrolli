using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;

using System.Linq;
using X.PagedList;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public PaymentController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_aesc" : "";

            var Payments = _unitOfWork.Payment.GetAll(includeProperties: "Employee,CashBox");

            switch (sortOrder)
            {
                case "date_aesc":
                    Payments = Payments.OrderBy(s => s.Date);
                    break;
                default:
                    Payments = Payments.OrderByDescending(s => s.Date);
                    break;
            }

            var paginatedEndShifts = Payments.ToPagedList(page ?? 1, 5);
            return View(paginatedEndShifts);
        }



        //GET
        public IActionResult AddPayment(int? id)
        {
            PaymentVM PaymentVM = new()
            {
                Payment = new(),
                EmployeeList = _unitOfWork.Employees.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FirstName,
                    Value = i.Id.ToString()
                }),
                CashBoxList = _unitOfWork.CashBox.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TypesOptions = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                //Create 
                return View(PaymentVM);
            }
            else
            {
                //Update 
                PaymentVM.Payment = _unitOfWork.Payment.GetFirstOrDefault(u => u.Id == id);
                return View(PaymentVM);
            }



        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPayment(PaymentVM obj)
        {
            if (ModelState.IsValid)
            {
                Payment payment = obj.Payment;

                payment.Date = DateTime.Now;

                var cashBox = _unitOfWork.CashBox.GetFirstOrDefault(c => c.Id == payment.CashBoxId);

                if (cashBox != null)
                {

                    
                    cashBox.CurrentAmount -= payment.ThePrice;

                    if (cashBox.CurrentAmount >= 0)
                    {

                            _unitOfWork.CashBox.Update(cashBox);
                            _unitOfWork.Payment.Add(payment);
                            _unitOfWork.Save();

                            TempData["success"] = "Shift ended successfully.";
                            return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("PaymentError", "The Payment Is Greater Then The Cash Box Current Value.");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Cash Box not found.");
                }
            }

            obj.EmployeeList = _unitOfWork.Employees.GetAll().Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.FirstName
            });
            obj.CashBoxList = _unitOfWork.CashBox.GetAll().Select(cb => new SelectListItem
            {
                Value = cb.Id.ToString(),
                Text = cb.Name
            });
            obj.TypesOptions = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>()
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
            var EndShiftFromDbFirst = _unitOfWork.Payment.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "Employee");
            if (EndShiftFromDbFirst == null)
            {
                return NotFound();
            }
            return View(EndShiftFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Payment.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Payment.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "The Record deleted successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Detales(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EndShiftFromDbFirst = _unitOfWork.Payment.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "Employee");
            if (EndShiftFromDbFirst == null)
            {
                return NotFound();
            }
            return View(EndShiftFromDbFirst);
        }

    }
}
