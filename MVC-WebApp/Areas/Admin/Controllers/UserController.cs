using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Areas.Admin.Models;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Controllers;

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

        public IActionResult UserDetail(string email)
        {
            var userAccount = usersManager.TryGetByName(email);
            return View(userAccount);
        }

        public IActionResult UserChangePassword(string email)
        {
            var changePassword = new ChangePassword()
            {
                UserAccountName = email,
            };
            return View(changePassword);
        }
         
        [HttpPost]
        public IActionResult UserChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                usersManager.ChangePassword(changePassword.UserAccountName, changePassword.UserAccountPassword);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Login));
        }
    }
}
