﻿using Microsoft.AspNetCore.Mvc;

namespace MVC_WebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
    }
}