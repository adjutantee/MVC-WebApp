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
    }
}
