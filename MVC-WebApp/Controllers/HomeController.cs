using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using OnlineWebApp_MVC.Services;
using System.Diagnostics;

namespace OnlineWebApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository productRepository;

        public HomeController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            return View(products);
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