using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petrol_Station_Manegement_System.Areas.Admin.Controllers;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using PetrolStation.Models.ViewModels;
using System.Diagnostics;
using System.Net.Mail;
using X.PagedList;



namespace Petrol_Station_Manegement_System.Areas.Customer.Controllers
{
    public class CustomerMessageController : Controller
    {
        private readonly ILogger<CustomerMessageController> _logger;
        private readonly IUnitOfwork _unitOfWork;
       

        public CustomerMessageController(ILogger<CustomerMessageController> logger, IUnitOfwork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
           
        }

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_aesc" : "";
            IEnumerable<CustomerMessage> CustomerMessageList = _unitOfWork.CustomerMessage.GetAll();
            switch (sortOrder)
            {
                case "date_aesc":
                    CustomerMessageList = CustomerMessageList.OrderBy(s => s.SendTime);
                    break;
                default:
                    CustomerMessageList = CustomerMessageList.OrderByDescending(s => s.SendTime);
                    break;
            }
            var message = CustomerMessageList.ToPagedList(page ?? 1, 5);

            return View(message);
        }
        //GET
        public IActionResult Contact()
        {

            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(CustomerMessage obj)
        {
            if (ModelState.IsValid)
            {
                obj.SendTime = DateTime.Now;
                _unitOfWork.CustomerMessage.Add(obj);
                
                MailModel model = new MailModel();
                model.Body = "We recived your email thank you for your time";
                model.Subject = "New Fuel Request";
                model.To = obj.Email;
                model.From = "orwa.wk98@gmail.com";
                SendEmail(model);
                _unitOfWork.Save();
                TempData["success"] = "Message send successfully";
                
            }
            return RedirectToAction("Index", "Home");
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

    }
}