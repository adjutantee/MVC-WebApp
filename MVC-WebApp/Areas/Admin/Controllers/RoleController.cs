﻿using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Areas.Admin.Models;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;
using System;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
             var roles = rolesRepository.GetAllRole();
            return View(roles);
        }

        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Index");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует!");
            }

            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}