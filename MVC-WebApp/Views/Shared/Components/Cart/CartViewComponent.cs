using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Services;

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
            var productCounts = cart?.Amount ?? 0;
            if (productCounts == 0)
            {
                return View("Empty", string.Empty);
            }
            return View("Cart", productCounts);
        }
    }
}
