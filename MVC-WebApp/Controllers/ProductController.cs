using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using System;

namespace MVC_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetById(id);
            return View(product);
        }
    }
}
