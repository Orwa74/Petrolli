using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Mail;
using X.PagedList;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class FuelRequestController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;

        public FuelRequestController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_aesc" : "";
            var FuelRequests = _unitOfWork.FuelRequest.GetAll(includeProperties: "FuelType,Supplier");

            switch (sortOrder)
            {
                case "date_aesc":
                    FuelRequests = FuelRequests.OrderBy(s => s.JoinDate);
                    break;
                default:
                    FuelRequests = FuelRequests.OrderByDescending(s => s.JoinDate);
                    break;
            }

            var paginatedEndShifts = FuelRequests.ToPagedList(page ?? 1, 5);
            return View(paginatedEndShifts);
        }

        // GET
        public IActionResult Add()
        {
            var FuelRequestVM = new FuelRequestVM
            {
                FuelTypeList = _unitOfWork.FuelType.GetAll().Select(ft => new SelectListItem
                {
                    Text = ft.Fuel_Type,
                    Value = ft.Id.ToString()
                }),
                SupplierList = _unitOfWork.Supplier.GetAll().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
            };

            return View(FuelRequestVM);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FuelRequestVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FuelRequest.Add(obj.FuelRequest);
               var supplier = _unitOfWork.Supplier.GetFirstOrDefault(t => t.Id == obj.FuelRequest.SupplierId);
               var fuelType = _unitOfWork.FuelType.GetFirstOrDefault(t => t.Id == obj.FuelRequest.FuelTypeId);
                string emailBody = $"<h3>:Fuel Type <h3 />{fuelType.Fuel_Type}" +
                     $"<h3>:Fuel Amount <h3 />{obj.FuelRequest.Amount} Litter" + 
                     $"<h3>:Notes <h3 />{obj.FuelRequest.Notes} ";
                MailModel model = new MailModel();
                model.Body = emailBody;
                model.Subject = "New Fuel Request";
                model.To = supplier.Email;
                model.From = "orwa.wk98@gmail.com";
                SendEmail(model);
                obj.FuelRequest.JoinDate = DateTime.Now;
                _unitOfWork.Save();


                TempData["success"] = "Fuel Request Added successfully";
                return RedirectToAction("Index");
            }
            obj.FuelTypeList = _unitOfWork.FuelType.GetAll().Select(ft => new SelectListItem
            {
                Text = ft.Fuel_Type,
                Value = ft.Id.ToString()
            });
            obj.SupplierList = _unitOfWork.Supplier.GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
            return View(obj);
        }

        public void SendEmail(MailModel _objModelMail)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(_objModelMail.To);
            mail.From = new MailAddress(_objModelMail.From);
            mail.Subject = _objModelMail.Subject;
            string Body = _objModelMail.Body;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("orwa.wk98@gmail.com", "plev wqbn qjvt kxau"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var RequestFromDbFirst = _unitOfWork.FuelRequest.GetFirstOrDefault(u => u.Id == id,
                includeProperties:"FuelType,Supplier");
            if (RequestFromDbFirst == null)
            {
                return NotFound();
            }
            return View(RequestFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.FuelRequest.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.FuelRequest.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Request deleted successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Detales(int id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var RequestFromDbFirst = _unitOfWork.FuelRequest.GetFirstOrDefault(u => u.Id == id,
                includeProperties: "FuelType,Supplier");
            if (RequestFromDbFirst == null)
            {
                return NotFound();
            }
            return View(RequestFromDbFirst);
        }
    }
}
