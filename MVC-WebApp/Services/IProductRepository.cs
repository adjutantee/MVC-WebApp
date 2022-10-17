using OnlineWebApp_MVC.Models;
using System.Collections.Generic;

namespace OnlineWebApp_MVC.Services
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        Product TryGetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Remove(int product);
    }
}