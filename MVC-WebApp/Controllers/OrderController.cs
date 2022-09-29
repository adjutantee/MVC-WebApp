﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Buy(Order order)
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
