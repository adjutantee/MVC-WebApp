using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Helpers;
using MVC_WebApp.Models;
using MVC_WebApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartRepository;

        public CartViewComponent(ICartsRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var productCounts = cartViewModel?.Items.Sum(x => x.Amount) ?? 0;
            if (productCounts == 0)
            {
                return View("Empty", string.Empty);
            }
            return View("Cart", cartViewModel);
        }
    }

    
}
