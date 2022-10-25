using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetByUserId(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult OrderDetailsStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Index");
        }
    }
}
