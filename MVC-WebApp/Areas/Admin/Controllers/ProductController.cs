using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Helpers;
using OnlineWebApp_MVC.Models;
using System;
using System.Collections.Generic;

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
            
            return View(Mapping.ToProductViewModel(products));
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };
            productRepository.Add(productDb);
            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };

            productRepository.Update(productDb);
            return RedirectToAction("Index");
        }

        public IActionResult ClearProduct(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Index");
        }
    }
}
