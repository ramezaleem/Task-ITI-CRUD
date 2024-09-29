using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC02.Data;
using MVC02.ViewModels;
using MVC02.Models;
using System.Linq;

namespace MVC02.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController()
        {
            _context = new();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            User? user = _context.Users.SingleOrDefault(e => e.Email == login.Email && e.Password == login.Password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }

            HttpContext.Session.SetString("UserName", user.Name); 
            HttpContext.Session.SetInt32("UserId", user.Id); 

            return RedirectToAction("Details", "User", new { Id = user.Id });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
