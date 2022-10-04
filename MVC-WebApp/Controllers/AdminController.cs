using Microsoft.AspNetCore.Mvc;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;

namespace MVC_WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;

        public AdminController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Orders()
        {
            return View();
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
        public IActionResult Add(Product product)
        {
            productRepository.Add(product);
            return View();
        }
    }
}
