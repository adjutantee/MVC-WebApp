﻿using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.Helpers;
using MVC_WebApp.Models;
using MVC_WebApp.Services;

namespace MVC_WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            if (ModelState.IsValid)
            {
                var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);

                var existingCartViewModel = Mapping.ToCartViewModel(existingCart);

                var order = new Order()
                {
                    User = user,
                    Items = existingCartViewModel.Items
                };
                ordersRepository.Add(order);
                cartsRepository.Clear(Constants.UserId);
                return View();
            }
            return View();
        }
    }
}
