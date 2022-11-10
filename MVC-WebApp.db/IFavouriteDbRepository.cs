using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;

namespace MVC_WebApp.db
{
    public interface IFavouriteDbRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void Delete(Guid productId, string userId);
        List<Product> GetFavourites(string userid);
    }
}