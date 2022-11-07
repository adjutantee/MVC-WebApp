using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Services;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userAccounts = userManager.GetAllUsers();
            return View(userAccounts);
        }
    }
}
