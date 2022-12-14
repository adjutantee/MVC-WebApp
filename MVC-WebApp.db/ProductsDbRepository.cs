using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_WebApp.db
{
    public class ProductsDbRepository : IProductRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductsDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(Product product)
        {
            product.ImagePath = "/css/PHTTest.png";
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return dataBaseContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            existingProduct.ImagePath = product.ImagePath;
            dataBaseContext.SaveChanges();
        }

        public void Remove(Guid product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(x => x.Id == product);
            dataBaseContext.Products.Remove(existingProduct);
            dataBaseContext.SaveChanges();
        }
    }
}
