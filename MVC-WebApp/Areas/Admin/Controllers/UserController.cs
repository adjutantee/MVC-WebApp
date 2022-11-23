using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Areas.Admin.Models;
using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Helpers;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System.Linq;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userAccounts = userManager.Users.ToList();
            return View(userAccounts.Select(x => x.ToUserViewModel()).ToList());
        }

        public IActionResult UserDetail(string name)
        {
            var userAccount = userManager.FindByNameAsync(name).Result;
            return View(userAccount.ToUserViewModel());
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
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult UserEdit(string name)
        {
            var userAccount = userManager.Users.ToList();
            return View(userAccount.Select(x => x.ToUserViewModel()).ToList());
        }

        [HttpPost]
        public IActionResult UserEdit(UserViewModel user)
        {
            //if (ModelState.IsValid)
            //{
            //    userManager.UserEdit(user);
            //    return RedirectToAction(nameof(Index));
            //}
            return View(userManager);
        }

        public IActionResult DeleteUser(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
