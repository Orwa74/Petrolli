using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using Petrol_Station_Manegement_System.DataAccess;
using PetrolStation.DataAccess.Repository.IRepository;
using PetrolStation.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;


        public UserController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _unitOfWork.User.GetAll();
            return View(objUserList);
        }

        //GET
        public IActionResult Create()
        {
            return View();

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(obj.Password, out passwordHash, out passwordSalt);
            obj.PasswordHash = passwordHash;
            obj.PasswordSalt = passwordSalt;
            _unitOfWork.User.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //GET
        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Login( string username, string password)
        {
            var user =  _unitOfWork.User.GetFirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                ModelState.AddModelError("UsertError", "The User Name is not correct.");
                return View();

            }
            if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                ModelState.AddModelError("UsertError", "The Password is not correct.");

                return View();

            }
            HttpContext.Session.SetString("Name", user.UserName);
            return RedirectToAction("Index", "Dashboard");
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var UserFromDbFirst = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            if (UserFromDbFirst == null)
            {
                return NotFound();
            }
            return View(UserFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "User updated successfully";
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
            var UserFromDbFirst = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            if (UserFromDbFirst == null)
            {
                return NotFound();
            }
            return View(UserFromDbFirst);

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.User.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");

        }
    }
}


