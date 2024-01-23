using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;

using System.Linq;
using X.PagedList;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class EndShiftController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public EndShiftController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_aesc" : "";

            var endShifts = _unitOfWork.EndShift.GetAll(includeProperties: "Pump,Shift,Employee,CashBox");

            switch (sortOrder)
            {
                case "date_aesc":
                    endShifts = endShifts.OrderBy(s => s.Date);
                    break;
                default:
                    endShifts = endShifts.OrderByDescending(s => s.Date);
                    break;
            }

            var paginatedEndShifts = endShifts.ToPagedList(page ?? 1, 5);

            return View(paginatedEndShifts);
        }





        //GET
        public IActionResult End_Shift(int? id)
        {
            EndShiftVM EndShiftVM = new()
            {
                EndShift = new(),
                PumpList = _unitOfWork.Pump.GetAll().Select(i => new SelectListItem
                {
                    Text = i.PumpCode,
                    Value = i.Id.ToString()
                }),
                ShiftList = _unitOfWork.Shift.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                EmployeeList = _unitOfWork.Employees.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FirstName,
                    Value = i.Id.ToString()
                }),
                CashBoxList = _unitOfWork.CashBox.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

                return View(EndShiftVM);
           
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult End_Shift(EndShiftVM obj)
        {
            if (ModelState.IsValid)
            {
                EndShift endShift = obj.EndShift;

                endShift.Date = DateTime.Now;

                var pump = _unitOfWork.Pump.GetFirstOrDefault(p => p.Id == endShift.PumpId);
                var tank = _unitOfWork.Tank.GetFirstOrDefault(t => t.Id == pump.TankId);
                var cashBox = _unitOfWork.CashBox.GetFirstOrDefault(c => c.Id == endShift.CashBoxId);

                if (pump != null && tank != null)
                {

                    endShift.PumpLastMeter = (int)pump.CurrerntMeter; 
                    

                    tank.Current_Quantity -= (endShift.PumpMeter - endShift.PumpLastMeter);

                    endShift.TotalProce = endShift.Price * (decimal)(endShift.PumpMeter - endShift.PumpLastMeter);

                    cashBox.CurrentAmount += endShift.TotalProce;

                    if(tank.Current_Quantity >= 0)
                    {
                        if (endShift.PumpMeter > pump.CurrerntMeter)
                        {
                            pump.CurrerntMeter = endShift.PumpMeter;

                            _unitOfWork.Pump.Update(pump);
                            _unitOfWork.Tank.Update(tank);

                            _unitOfWork.EndShift.Add(endShift);
                            _unitOfWork.Save();

                            TempData["success"] = "Shift ended successfully.";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("EndShiftError", "The Pump Meter Value Should be More Than The Pump Current Meter.");
                        }
                    }
                    else 
                    {
                        ModelState.AddModelError("EndShiftError", "The Fuel Amount Is Greater Then The Fuel Tank Current Quantity.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Pump or Tank not found.");
                }
            }

            obj.PumpList = _unitOfWork.Pump.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.PumpCode
            });
            obj.EmployeeList = _unitOfWork.Employees.GetAll().Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.FirstName
            });
            obj.ShiftList = _unitOfWork.Shift.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });
            obj.CashBoxList = _unitOfWork.CashBox.GetAll().Select(cb => new SelectListItem
            {
                Value = cb.Id.ToString(),
                Text = cb.Name
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
            var EndShiftFromDbFirst = _unitOfWork.EndShift.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "Pump,Employee,Shift");
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
            var obj = _unitOfWork.EndShift.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.EndShift.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "The Record deleted successfully";
            return RedirectToAction("Index");

        }

        //Get
        public IActionResult Detales(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EndShiftFromDbFirst = _unitOfWork.EndShift.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "Pump,Employee,Shift");
            if (EndShiftFromDbFirst == null)
            {
                return NotFound();
            }
            return View(EndShiftFromDbFirst);
        }

    }
}
