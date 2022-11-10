using Microsoft.EntityFrameworkCore;
using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CartsDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return dataBaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId) // Добавление в корзину
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null) // Если у пользователя нет корзины, создаем новую
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>
                {
                    new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = newCart
                    }
                };

                dataBaseContext.Carts.Add(newCart);
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
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }

            dataBaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);// Проверяет есть ли позиция с таким же продуктом

            if (existingCartItem == null)
            {
                return;
            }

            existingCartItem.Amount -= 1;

            if (existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }

            dataBaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            dataBaseContext.Carts.Remove(existingCart);
            dataBaseContext.SaveChanges();
        }
    }
}
