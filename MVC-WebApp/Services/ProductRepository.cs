using System.Collections.Generic;
using System.Linq;
using OnlineWebApp_MVC.Models;

namespace OnlineWebApp_MVC.Services
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Name1", "Кроссовки фирмы Nike",
                "Nike", "Force", 39-41, 15000),
            new Product("Name2", "Кроссовки фирмы Nike",
                "Nike", "Force", 41-42, 12000),
            new Product("Name3", "Кроссовки фирмы Nike",
                "Nike", "Force", 42-44, 19000),
        };

        public List<Product> GetAllProduct()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
