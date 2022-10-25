using Microsoft.AspNetCore.Mvc;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;

namespace MVC_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAllProduct();
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
            productRepository.Add(product);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public IActionResult ClearProduct(int productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Index");
        }
    }
}
