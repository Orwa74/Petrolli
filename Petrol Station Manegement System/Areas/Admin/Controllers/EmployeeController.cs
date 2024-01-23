using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Linq;
using X.PagedList;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public EmployeeController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index(int? page, string sortOrder, string searchString)
        {
            var emp = new EmployeeVM();
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var employees = _unitOfWork.Employees.GetAll(includeProperties: "Shift");

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
            }

            var Emp = employees.ToPagedList(page ?? 1, 5);

            return View(Emp);
        }




        //GET
        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new()
            {
                Employee = new(),
                ShiftList = _unitOfWork.Shift.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name, //Shift Name
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0) 
            {
                //Create Employee
                return View(employeeVM);
            }
            else
            {
                //Update Employee
                employeeVM.Employee = _unitOfWork.Employees.GetFirstOrDefault(u => u.Id == id);
                return View(employeeVM);
            }
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmployeeVM obj)
        {
            if (ModelState.IsValid)
            {
                Employee employee = obj.Employee;

                if (obj.Employee.Id == 0)
                {
                    _unitOfWork.Employees.Add(obj.Employee);
                    TempData["success"] = "Employee Added successfully";
                }
                else
                {
                    _unitOfWork.Employees.Update(obj.Employee);
                    TempData["success"] = "Employee updated successfully";
                }
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            obj.ShiftList = _unitOfWork.Shift.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name, //Shift Name
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
            var EmployeeFromDbFirst = _unitOfWork.Employees.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "Shift");
            if (EmployeeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Employees.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employees.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");

        }

       

    }
}
