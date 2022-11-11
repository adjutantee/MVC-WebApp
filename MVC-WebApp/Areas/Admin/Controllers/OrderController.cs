using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Models;
using MVC_WebApp.Helpers;
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
            return View(orders.ToOrderViewModels());
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetByUserId(orderId);
            return View(order.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult OrderDetailsStatus(Guid orderId, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction("Index");
        }
    }
}
