using MVC_WebApp.db.Models;
using System;

namespace MVC_WebApp.db
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart TryGetByUserId(string userId);
    }
}