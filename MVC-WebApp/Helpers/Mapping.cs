using MVC_WebApp.db;
using MVC_WebApp.db.Models;
using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using System.Collections.Generic;

namespace MVC_WebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModel(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagePath = product.ImagePath,
            };
        }

        public static CartVievModel ToCartViewModel(Cart cart)
        {
            if (cart == null) return null;

            return new CartVievModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static List<OrderViewModel> ToOrderViewModels(this List<Order> orders)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModel.Add(ToOrderViewModel(order)); 
            }
            return ordersViewModel;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Date = order.Date,
                Time = order.Time,
                Items = ToCartItemViewModels(order.Items),
                UserDeliveryInfo = ToUserDeliveryInfoViewModel(order.UserDeliveryInfo),
                Status = (OrderStatusViewModel)(int)order.Status
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo userDeliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                userOrderName = userDeliveryInfo.userOrderName,
                userOrderEmail = userDeliveryInfo.userOrderEmail,
                userOrderPhone = userDeliveryInfo.userOrderPhone,
                userAdres = userDeliveryInfo.userAdres,
                userOrderMessage = userDeliveryInfo.userOrderMessage,
            };
        }

        public static UserDeliveryInfo ToDbDelivery(UserDeliveryInfoViewModel userDeliveryInfo)
        {
            return new UserDeliveryInfo
            {
                userOrderName = userDeliveryInfo.userOrderName,
                userOrderEmail = userDeliveryInfo.userOrderEmail,
                userOrderPhone = userDeliveryInfo.userOrderPhone,
                userAdres = userDeliveryInfo.userAdres,
                userOrderMessage = userDeliveryInfo.userOrderMessage,
            };
        }
    }
}
