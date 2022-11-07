using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Controllers;

namespace MVC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;

        public AccountController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            var userAccount = userManager.TryGetByName(login.exampleLoginEmail);

            if(userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не сущетсвует");
                return RedirectToAction(nameof(Login));
            }

            if (userAccount.Password != login.exampleLoginPassword)
            {
                ModelState.AddModelError("", "Не верный логин или пароль");
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)  
        { 
            if (ModelState.IsValid)
            {
                userManager.Add(new UserAccount
                { 
                    Name = register.exampleLoginName,
                    NumberPhone = register.exampleLoginNumberPhone,
                    Email = register.exampleLoginEmail,
                    Password = register.exampleLoginPassword,
                });
                return RedirectToAction(nameof(HomeController.Index),"Home");
            }
            return RedirectToAction(nameof(Register));
        }

    }
}
