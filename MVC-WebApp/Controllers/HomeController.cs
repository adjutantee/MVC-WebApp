using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.Helpers;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineWebApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public HomeController(IProductRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            //var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            //ViewBag.ProductCount = cart?.Amount;
            var products = productRepository.GetAllProduct();
            return View(Mapping.ToProductViewModel(products));
        }

        [HttpPost]
        public IActionResult ProductSearch(string name)
        {
            if (name != null)
            {
                var productSearch = productRepository.GetAllProduct().FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
                return View(Mapping.ToProductViewModel(productSearch));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}