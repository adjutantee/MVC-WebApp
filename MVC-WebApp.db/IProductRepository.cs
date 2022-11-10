using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;

namespace MVC_WebApp.db
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        Product TryGetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Remove(Guid product);
    }
}