﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Buy()
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
