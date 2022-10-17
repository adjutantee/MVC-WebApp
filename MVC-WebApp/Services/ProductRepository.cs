using System.Collections.Generic;
using System.Linq;
using OnlineWebApp_MVC.Models;

namespace OnlineWebApp_MVC.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Name1", "Кроссовки фирмы Nike",
                "/css/PHTTest.png", 15000),
            new Product("Name2", "Кроссовки фирмы Nike",
                "/css/PHTTest.png", 12000),
            new Product("Name3", "Кроссовки фирмы Nike",
                "/css/PHTTest.png", 19000),
        };

        public void Add(Product product)
        {
            product.ImagePath = "/css/PHTTest.png";
            products.Add(product);
        }

        public List<Product> GetAllProduct()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);
            
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            existingProduct.ImagePath = product.ImagePath;
        }

        public void Remove(int product)
        {
            var existingProduct = products.FirstOrDefault(x => x.Id == product);
            products.Remove(existingProduct);
        }
    }
}
