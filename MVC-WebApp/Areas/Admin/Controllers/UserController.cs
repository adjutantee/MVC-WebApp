using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Services;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager usersManager;

        public UserController(IUserManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccounts = usersManager.GetAllUsers();
            return View(userAccounts);
        }

        public IActionResult UserDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserDetail(UserManager user)
        {
            return View();
        }
    }
}
