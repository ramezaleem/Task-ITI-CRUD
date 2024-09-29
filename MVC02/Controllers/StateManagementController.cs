using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{

    public class StateManagementController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string data)
        {

            Response.Cookies.Append("SavedData",data);
            return RedirectToAction("Show");
        }

        public IActionResult Show()
        {
            var data = Request.Cookies["SavedData"];
            return View("Show",data);
        }
    }
}
