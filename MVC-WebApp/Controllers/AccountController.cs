using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Controllers;

namespace MVC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager usersManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUserManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {

            }
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.exampleLoginEmail, login.exampleLoginPassword, login.exampleLoginCheckBox, false).Result;

                if (result.Succeeded) return Redirect(login.ReturnUrl ?? "/Home");

                else ModelState.AddModelError("", "Неправильный логин или пароль!");
            }

            return View(login);

        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.exampleRegisterName == register.exampleRegisterPassword)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = register.exampleRegisterEmail,
                    UserName = register.exampleRegisterName,
                    PhoneNumber = register.exampleRegisterNumberPhone
                };

                var result = _userManager.CreateAsync(user, register.exampleRegisterPassword).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRole(user);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(register);
        }
     
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
