using MVC_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.Services
{
    public static class CartsRepository
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
