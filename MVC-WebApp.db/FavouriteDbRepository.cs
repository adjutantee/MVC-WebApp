using Microsoft.EntityFrameworkCore;
using MVC_WebApp.db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WebApp.db
{
    public class FavouriteDbRepository : IFavouriteDbRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FavouriteDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public List<Product> GetFavourites(string userid)
        {
            return dataBaseContext.FavoriteProducts.Where(x => x.UserId == userid).Include(x => x.Product).Select(x => x.Product).ToList();
        }

        public void Add(Product product, string userId)
        {
            var existingProduct = dataBaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                dataBaseContext.FavoriteProducts.Add(new FavouriteProduct
                {
                    Product = product,
                    UserId = userId,
                });
                dataBaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var existingFavourite = dataBaseContext.FavoriteProducts.Where(x => x.UserId == userId).ToList();
            dataBaseContext.FavoriteProducts.RemoveRange(existingFavourite);
            dataBaseContext.SaveChanges();
        }

        public void Delete(Guid productId, string userId)
        {
            var existingFavourite = dataBaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            dataBaseContext.FavoriteProducts.Remove(existingFavourite);
            dataBaseContext.SaveChanges();
        }
    }
}
