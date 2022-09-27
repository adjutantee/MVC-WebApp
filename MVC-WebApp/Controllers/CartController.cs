using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Services;
using OnlineWebApp_MVC.Services;

namespace MVC_WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository productRepository;

        public CartController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
