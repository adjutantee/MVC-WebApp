using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;

namespace MVC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            return RedirectToAction("Index", "Home");
        }
        
    }
}
