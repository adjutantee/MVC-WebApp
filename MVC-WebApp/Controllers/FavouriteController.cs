using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.Helpers;
using MVC_WebApp.Services;

namespace MVC_WebApp.Controllers
{
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
    }
}
