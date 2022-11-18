using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.Helpers;
using MVC_WebApp.Services;
using System;

namespace MVC_WebApp.Controllers
{
    [Authorize]
    public class FavouriteController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFavouriteDbRepository favouriteDbRepository;

        public FavouriteController(IProductRepository productRepository, IFavouriteDbRepository favouriteDbRepository)
        {
            this.productRepository = productRepository;
            this.favouriteDbRepository = favouriteDbRepository;
        }

        public IActionResult Index()
        {
            var product = favouriteDbRepository.GetFavourites(Constants.UserId);
            return View(Mapping.ToProductViewModel(product));
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            favouriteDbRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favouriteDbRepository.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid productId)
        {
            favouriteDbRepository.Delete(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}
