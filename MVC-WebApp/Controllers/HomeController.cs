using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;
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
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.ProductCount = cart?.Amount;
            var products = productRepository.GetAllProduct();
            return View(products);
        }

        [HttpPost]
        public IActionResult ProductSearch(string name)
        {
            if (name != null)
            {
                var productSearch = productRepository.GetAllProduct().FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
                return View(productSearch);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}