﻿using Microsoft.AspNetCore.Mvc;
using OnlineWebApp_MVC.Services;

namespace MVC_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetById(id);
            return View(product);
        }
    }
}
