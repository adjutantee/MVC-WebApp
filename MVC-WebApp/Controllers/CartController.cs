using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Services;

namespace MVC_WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly CartsRepository cartsRepository;

        public CartController(ProductRepository productRepository, CartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
