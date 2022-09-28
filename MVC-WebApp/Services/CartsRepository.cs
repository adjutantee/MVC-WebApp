using MVC_WebApp.Models;
using OnlineWebApp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public class CartsRepository : ICartsRepository
    {
        private List<Cart> carts = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId) // Добавление в корзину
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null) // Если у пользователя нет корзины, создаем новую
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem()
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };

                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id); // Проверяет есть ли позиция с таким же продуктом
                if (existingCartItem != null) // Если есть, добавляем +1
                {
                    existingCartItem.Amount += 1;
                }
                else // Если нет, создаем новую позицию
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }
    }
}
