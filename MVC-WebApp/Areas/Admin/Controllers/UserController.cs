using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MVC_WebApp.Areas.Admin.Models;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Controllers;

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

        public IActionResult UserDetail(string name)
        {
            var userAccount = userManager.TryGetByName(name);
            return View(userAccount);
        }
        
        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                userManager.ChangePassword(changePassword.UserName, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult UserEdit(string name)
        {
            var userAccount = userManager.TryGetByName(name);
            return View(userAccount);
        }

        [HttpPost]
        public IActionResult UserEdit(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                userManager.UserEdit(user);
                return RedirectToAction(nameof(Index));
            }
            return View(userManager);
        }

        public IActionResult DeleteUser(string name)
        {
            userManager.Remove(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
