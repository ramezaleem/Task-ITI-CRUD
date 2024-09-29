using Microsoft.AspNetCore.Mvc;
using MVC02.Data;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new();
        }

        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return Content("User Not Found");
            }

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["Message"] = "User created successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == id);

            if (user == null) return Content("User not Found");
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            User existingUser = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            if (existingUser == null) return Content("User not Found");

            existingUser.Name = user.Name;
            existingUser.Age = user.Age;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _context.SaveChanges();
            TempData["Message"] = "User updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null) return Content("User not Found");

            _context.Users.Remove(user);
            _context.SaveChanges();
            TempData["Message"] = "User deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
