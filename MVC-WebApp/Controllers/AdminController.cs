using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;
using System;

namespace MVC_WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrdersRepository ordersRepository;

        public AdminController(IProductRepository productRepository, IOrdersRepository ordersRepository)
        {
            this.productRepository = productRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            if (orders == null || orders.Count == 0)
            {
                return View("notFound");
            }
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var orders = ordersRepository.TryGetByUserId(orderId);
            return View(orders);
        }

        public IActionResult OrderDetailsStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
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
            var products = productRepository.GetAllProduct();
            if (products == null || products.Count == 0)
            {
                return View("notFound");
            }
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Update(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Update(product);
            return RedirectToAction("Products");
        }

        public IActionResult ClearProduct(int productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Products");
        }
    }
}
