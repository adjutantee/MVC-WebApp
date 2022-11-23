﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Areas.Admin.Models;
using MVC_WebApp.db;
using OnlineWebApp_MVC.Services;
using System.Linq;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles.Select(x => new RoleViewModel { Name = x.Name }).ToList());
        }

        public IActionResult RemoveRole(string roleName)
        {
            var role = roleManager.FindByNameAsync(roleName).Result;

            if (role != null)
            {
                roleManager.DeleteAsync(role).Wait();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(RoleViewModel role)
        {
            var result = roleManager.CreateAsync(new IdentityRole(role.Name)).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(role);
        }
    }
}
